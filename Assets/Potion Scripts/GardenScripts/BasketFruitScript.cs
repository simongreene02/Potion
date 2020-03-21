using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketFruitScript : MonoBehaviour, ActivateOnClickScript {
	public static int uncollectedSeeds;

	// Use this for initialization
	void Start () {
		uncollectedSeeds++;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		if (BasketBScript.plantingSeeds && !BasketBScript.holdingSeed) {
			BasketBScript.holdingSeed = true;
			uncollectedSeeds--;
			this.gameObject.SetActive (false);
		}
	}
}
