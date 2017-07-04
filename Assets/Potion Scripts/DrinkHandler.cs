using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHandler : MonoBehaviour {

	private bool isMouseOn;
	[HideInInspector]
	public DrinkHandler[] childScripts;

	// Use this for initialization
	void Start () {
		childScripts = DrinkHandler [this.gameObject.transform.childCount];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter () {
		isMouseOn = true;
	}

	void OnMouseExit () {
		isMouseOn = false;
	}

	public bool IsMouseOn() {
		
	}
}
