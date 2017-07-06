using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	private bool isMouseOn;
	[HideInInspector]
	public ClickHandler[] childScripts;

	// Use this for initialization
	void Start () {
		childScripts = new ClickHandler[this.gameObject.transform.childCount];
		for (int i = 0; i < childScripts.Length; i++) {
			childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.AddComponent<ClickHandler> () as ClickHandler;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.parent == null) {
			print (IsMouseOn());
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
