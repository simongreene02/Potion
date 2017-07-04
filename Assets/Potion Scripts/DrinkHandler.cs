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
		Transform transform;
		RenderSettings.fogDensity = timesClicked * 0.1f;
		timeSinceClicked += Time.deltaTime;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.position.x == this.gameObject.transform.position.x && hit.transform.position.y == this.gameObject.transform.position.y && hit.transform.position.z == this.gameObject.transform.position.z) {
				//print ("This is a Player");
			} else {
				//print (hit.transform.position.ToString() + " " + this.gameObject.transform.position.ToString());                
			}
		} else {
			//print ("nope");
		}
	}

	void OnMouseEnter () {
		print ("This is a Player");
		if (timeSinceClicked > 0.3f) {
			timesClicked++;
			timeSinceClicked = 0f;
		}
		if (timesClicked == 11) {
			timesClicked = 0;
		}
	}
}
