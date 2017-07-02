using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHandler : MonoBehaviour {

	private float timeSinceClicked;
	private int timesClicked;
	private Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		timeSinceClicked = 1.0f;
		timesClicked = 0;
	}
	
	// Update is called once per frame
	void Update () {
		RenderSettings.fogDensity = timesClicked * 0.1f;
		timeSinceClicked += Time.deltaTime;
		print (timeSinceClicked);
		if(Physics.Raycast (ray, out hit))
		{
			if(hit.transform.name == "Player")
			{
				Debug.Log ("This is a Player");
			}
			else {
				Debug.Log ("This isn't a Player");                
			}
		}
	}

	void OnMouseDown () {
		if (timeSinceClicked > 0.3f) {
			timesClicked++;
			timeSinceClicked = 0f;
		}
		if (timesClicked == 11) {
			timesClicked = 0;
		}
	}
}
