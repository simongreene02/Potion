using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkOrderScript : MonoBehaviour {

	public DrinkScript drinkScript;
	public NecklaceScript necklaceScript;
	public readonly int maxDrinkThreshold = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		if (DrinkScript.drinksDrunk < maxDrinkThreshold) {
			drinkScript.OnActivate ();
		} else {
			necklaceScript.BringNecklaceToTable();
			DrinkScript.drinksDrunk = 0;
			this.gameObject.GetComponent<ClickHandlerDrinkOrderScript> ().enabled = false;
			this.enabled = false;
		}
	}
		
}
