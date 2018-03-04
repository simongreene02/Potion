using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkOrderScript : MonoBehaviour {

	public DrinkScript drinkScript;
	public NecklaceScript necklaceScript;
	public readonly int maxDrinkThreshold = 6;
	public ParticleSystem fog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (DrinkScript.drinksDrunk == 6) {
			fog.Stop();
		}
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
		if (DrinkScript.drinksDrunk == 1) {
			fog.Play();
		}
		if (DrinkScript.drinksDrunk == 2) {
			fog.Play();
		}
	}
		
}
