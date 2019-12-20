using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkOrderScript : MonoBehaviour {

	public DrinkScript drinkScript;
	public Animator necklaceAnimator;
	public readonly int maxDrinkThreshold = 6;
	public ParticleSystem fog;
	public NecklaceScript necklaceScript;

	// Use this for initialization
	void Start () {
		fog.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if (DrinkScript.drinksDrunk == 6) {
			fog.Stop();
		}
		if (DrinkScript.drinksDrunk == 0 && necklaceAnimator.GetBool ("combineShards") == true) {
			necklaceScript.enabled = true;
			this.enabled = false;
		}
	}

	public void OnBeingClicked() {
		if (FlagHandler.ContainsKey ("barActivated") && FlagHandler.GetItem ("barActivated") == 1) {
			if (DrinkScript.drinksDrunk < maxDrinkThreshold) {
				drinkScript.OnActivate ();
			} else {
				necklaceAnimator.SetBool("combineShards", true);
				this.gameObject.GetComponent<ClickHandlerDrinkOrderScript> ().enabled = false;
			}
			if (DrinkScript.drinksDrunk == 1) {
				fog.Play ();
			}
			if (DrinkScript.drinksDrunk == 2) {
				fog.Play ();
			}
		}
	}
		
}
