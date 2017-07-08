using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkOrderScript : MonoBehaviour {

	public DrinkScript drinkScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		drinkScript.OnActivate ();
	}
}
