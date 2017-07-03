using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHandler : MonoBehaviour {

	private float timeSinceClicked;
	private int timesClicked;

	// Use this for initialization
	void Start () {
		timeSinceClicked = 1.0f;
		timesClicked = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		RenderSettings.fogDensity = timesClicked * 0.1f;
		timeSinceClicked += Time.deltaTime;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.equals(this.gameObject.transform)) {
				print ("This is a Player");
			} else {
				print ("This isn't a Player");                
			}
		} else {
			print ("nope");
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
