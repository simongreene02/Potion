using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {
	private static Transform objectPointingAt;
	private static bool raycastChecked;

	private bool isMouseOn = false;
	//public ActivateOnClickScript clickScript;
	private ClickHandler[] childScripts;

	// Use this for initialization
	void Start () {
		childScripts = new ClickHandler[this.gameObject.transform.childCount];
		for (int i = 0; i < childScripts.Length; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandler> () == null) {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.AddComponent<ClickHandler> () as ClickHandler;
			} else {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandler> () as ClickHandler;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (raycastChecked) {
			objectPointingAt = null;
			raycastChecked = false;
			print ("Clearing raycast data.");
		}
		//print (this.gameObject.GetComponent (typeof(ActivateOnClickScript)));
		if (this.gameObject.GetComponent(typeof(ActivateOnClickScript)) != null) { //this.clickScript != null) {
			if (Input.GetMouseButtonDown (0) && IsMouseOn()) {
				(this.gameObject.GetComponent(typeof(ActivateOnClickScript)) as ActivateOnClickScript).OnBeingClicked ();
				print ("click");
			}
		}
	}

	void OnMouseEnter () {
		isMouseOn = true;
	}

	void OnMouseExit () {
		isMouseOn = false;
	}

	public bool IsMouseOn() {
		if (isMouseOn) {
			return true;
		}
		if (!raycastChecked) {
			print ("Setting raycast data.");
			raycastChecked = true;
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast(ray, out hit)) {
				objectPointingAt = hit.transform;
				print("Set raycast to " + hit.transform.name);
			}
		}

		//if (objectPointingAt == null) {
		//	return false;
		//}
		if (objectPointingAt == gameObject.transform) {
			return true;
		}
		if (childScripts == null) {
			return false;
		}
		for (int i = 0; i < childScripts.Length; i++) {
			if (childScripts [i].IsMouseOn()) {
				return true;
			}
		}
		return false;
	}
}
