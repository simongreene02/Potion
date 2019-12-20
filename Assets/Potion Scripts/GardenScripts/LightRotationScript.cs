using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightRotationScript : MonoBehaviour {

	public float rotationTime = 60f;
	public GameObject sun;
	public int sunDistance;
	public Vector3 sunCenter;
	private float totalTime = 0f;
	public event Action OnRotationCompleted;

	// Use this for initialization
	void OnDisable () {
		if (OnRotationCompleted != null) {
			OnRotationCompleted ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (totalTime < rotationTime) {
			this.gameObject.transform.Rotate (new Vector3 (Time.deltaTime / rotationTime * -360, 0, 0));
			sun.transform.Rotate (new Vector3 (Time.deltaTime / rotationTime * -360, 0, 0));
			float angle = (totalTime / rotationTime * 2 * Mathf.PI) - (1.5f*Mathf.PI);
			sun.transform.position = new Vector3 (sunCenter.x, sunCenter.y + (Mathf.Sin (angle) * sunDistance), sunCenter.z + (Mathf.Cos (angle) * sunDistance));
			totalTime += Time.deltaTime;
		} else {
			this.gameObject.transform.Rotate (new Vector3 ((rotationTime-totalTime) / rotationTime * -360, 0, 0));
			sun.transform.Rotate (new Vector3 ((rotationTime-totalTime) / rotationTime * -360, 0, 0));
			sun.transform.position = new Vector3 (sunCenter.x, sunCenter.y + (Mathf.Sin (0.5f*Mathf.PI) * sunDistance), sunCenter.z + (Mathf.Cos (0.5f*Mathf.PI) * sunDistance));
			this.enabled = false;
		}
	}
}
