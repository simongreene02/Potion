using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	private bool isMouseOn;
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
		//print (this.gameObject.GetComponent (typeof(ActivateOnClickScript)));
		if (this.gameObject.GetComponent(typeof(ActivateOnClickScript)) != null) { //this.clickScript != null) {
			if (Input.GetMouseButtonDown (0) && IsMouseOn()) {
				//clickScript.OnBeingClicked ();
				(this.gameObject.GetComponent(typeof(ActivateOnClickScript)) as ActivateOnClickScript).OnBeingClicked ();
				print ("click");
			}
		}
		if (Input.GetMouseButtonDown (0) && IsMouseOn()) {
			print ("click");
		}
		//print (IsMouseOn());
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
		for (int i = 0; i < childScripts.Length; i++) {
			if (childScripts [i].IsMouseOn()) {
				return true;
			}
		}
		return false;
	}
}
