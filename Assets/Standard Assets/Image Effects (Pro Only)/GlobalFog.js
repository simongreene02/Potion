
#pragma strict

@script ExecuteInEditMode
@script RequireComponent (Camera)
@script AddComponentMenu ("Image Effects/Rendering/Global Fog")

class GlobalFog extends PostEffectsBase {
	
	private var CAMERA_NEAR : float = 0.5f;
	private var CAMERA_FAR : float = 50.0f;
	private var CAMERA_FOV : float = 60.0f;	
	private var CAMERA_ASPECT_RATIO : float = 1.333333f;

	public var distanceFog : boolean = true;
	public var heightFog : boolean = true;
	public var height : float = 1.0f;
	@Range(0.001f,10.0f)
	public var heightDensity : float = 2.0f;
	public var startDistance : float = 0.0f;

	public var fogShader : Shader;
	private var fogMaterial : Material = null;	
	
	function CheckResources () : boolean {	
		CheckSupport (true);
	
		fogMaterial = CheckShaderAndCreateMaterial (fogShader, fogMaterial);
		
		if(!isSupported)
			ReportAutoDisable ();
		return isSupported;				
	}

	@ImageEffectOpaque
	function OnRenderImage (source : RenderTexture, destination : RenderTexture) {	
		if (CheckResources()==false || (!distanceFog && !heightFog))
		{
			Graphics.Blit (source, destination);
			return;
		}
			
		CAMERA_NEAR = GetComponent(Camera).nearClipPlane;
		CAMERA_FAR = GetComponent(Camera).farClipPlane;
		CAMERA_FOV = GetComponent(Camera).fieldOfView;
		CAMERA_ASPECT_RATIO = GetComponent(Camera).aspect;
	
		var frustumCorners : Matrix4x4 = Matrix4x4.identity;		
		var vec : Vector4;
		var corner : Vector3;
	
		var fovWHalf : float = CAMERA_FOV * 0.5f;
		
		var toRight : Vector3 = GetComponent(Camera).transform.right * CAMERA_NEAR * Mathf.Tan (fovWHalf * Mathf.Deg2Rad) * CAMERA_ASPECT_RATIO;
		var toTop : Vector3 = GetComponent(Camera).transform.up * CAMERA_NEAR * Mathf.Tan (fovWHalf * Mathf.Deg2Rad);
	
		var topLeft : Vector3 = (GetComponent(Camera).transform.forward * CAMERA_NEAR - toRight + toTop);
		var CAMERA_SCALE : float = topLeft.magnitude * CAMERA_FAR/CAMERA_NEAR;	
			
		topLeft.Normalize();
		topLeft *= CAMERA_SCALE;
	
		var topRight : Vector3 = (GetComponent(Camera).transform.forward * CAMERA_NEAR + toRight + toTop);
		topRight.Normalize();
		topRight *= CAMERA_SCALE;
		
		var bottomRight : Vector3 = (GetComponent(Camera).transform.forward * CAMERA_NEAR + toRight - toTop);
		bottomRight.Normalize();
		bottomRight *= CAMERA_SCALE;
		
		var bottomLeft : Vector3 = (GetComponent(Camera).transform.forward * CAMERA_NEAR - toRight - toTop);
		bottomLeft.Normalize();
		bottomLeft *= CAMERA_SCALE;
				
		frustumCorners.SetRow (0, topLeft); 
		frustumCorners.SetRow (1, topRight);		
		frustumCorners.SetRow (2, bottomRight);
		frustumCorners.SetRow (3, bottomLeft);		
		
		var camPos = GetComponent(Camera).transform.position;
		var FdotC : float = camPos.y-height;
		var paramK : float = (FdotC <= 0.0f ? 1.0f : 0.0f);
		fogMaterial.SetMatrix ("_FrustumCornersWS", frustumCorners);
		fogMaterial.SetVector ("_CameraWS", camPos);
		fogMaterial.SetVector ("_HeightParams", Vector4 (height, FdotC, paramK, heightDensity*0.5f));
		fogMaterial.SetVector ("_DistanceParams", Vector4 (-Mathf.Max(startDistance,0.0f), 0, 0, 0));
		
		var sceneMode = RenderSettings.fogMode;
		var sceneDensity = RenderSettings.fogDensity;
		var sceneStart = RenderSettings.fogStartDistance;
		var sceneEnd = RenderSettings.fogEndDistance;
		var sceneParams : Vector4;
		var linear : boolean = (sceneMode == UnityEngine.FogMode.Linear);
		var diff : float = linear ? sceneEnd - sceneStart : 0.0f;
		var invDiff : float = Mathf.Abs(diff) > 0.0001f ? 1.0f / diff : 0.0f;
		sceneParams.x = sceneDensity * 1.2011224087f; // density / sqrt(ln(2)), used by Exp2 fog mode
		sceneParams.y = sceneDensity * 1.4426950408f; // density / ln(2), used by Exp fog mode
		sceneParams.z = linear ? -invDiff : 0.0f;
		sceneParams.w = linear ? sceneEnd * invDiff : 0.0f;
		fogMaterial.SetVector ("_SceneFogParams", sceneParams);
		fogMaterial.SetInt ("_SceneFogMode", sceneMode);
		
		var pass : int = 0;
		if (distanceFog && heightFog)
			pass = 0; // distance + height
		else if (distanceFog)
			pass = 1; // distance only
		else
			pass = 2; // height only
		CustomGraphicsBlit (source, destination, fogMaterial, pass);
	}
	
	static function CustomGraphicsBlit (source : RenderTexture, dest : RenderTexture, fxMaterial : Material, passNr : int) {
		RenderTexture.active = dest;
		       
		fxMaterial.SetTexture ("_MainTex", source);	        
	        	        
		GL.PushMatrix ();
		GL.LoadOrtho ();	
	    	
		fxMaterial.SetPass (passNr);	
		
	    GL.Begin (GL.QUADS);
							
		GL.MultiTexCoord2 (0, 0.0f, 0.0f); 
		GL.Vertex3 (0.0f, 0.0f, 3.0f); // BL
		
		GL.MultiTexCoord2 (0, 1.0f, 0.0f); 
		GL.Vertex3 (1.0f, 0.0f, 2.0f); // BR
		
		GL.MultiTexCoord2 (0, 1.0f, 1.0f); 
		GL.Vertex3 (1.0f, 1.0f, 1.0f); // TR
		
		GL.MultiTexCoord2 (0, 0.0f, 1.0f); 
		GL.Vertex3 (0.0f, 1.0f, 0.0); // TL
		
		GL.End ();
	    GL.PopMatrix ();
	}		
}
