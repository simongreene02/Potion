using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	private bool isMouseOn;
	public ActivateOnClickScript clickScript;
	[HideInInspector]
	public ClickHandler[] childScripts;

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
		if (this.clickScript != null) {
			if (Input.GetMouseButtonDown (0)) {
				clickScript.OnBeingClicked ();
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
		for (int i = 0; i < childScripts.Length; i++) {
			if (childScripts [i].IsMouseOn()) {
				return true;
			}
		}
		return false;
	}
}
