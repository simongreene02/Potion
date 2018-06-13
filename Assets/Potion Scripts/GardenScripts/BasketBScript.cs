using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingSeed = false;
	public GameObject[] unplantedSeeds;
	private int seedsInCrate;
	public GameObject miniBasket;

	// Use this for initialization
	void Start () {
		seedsInCrate = unplantedSeeds.Length;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < unplantedSeeds.Length; i++) {
			unplantedSeeds[i].SetActive (i < seedsInCrate);
		}
		print (holdingSeed + " " + seedsInCrate);
		if (FlagHandler.ContainsKey ("carryingBasket")) {
			miniBasket.SetActive (FlagHandler.GetItem ("carryingBasket") == 1);
			this.gameObject.SetActive (FlagHandler.GetItem ("carryingBasket") == 0);
		}
	}

	public void OnBeingClicked() {
		if (FlagHandler.GetItem ("character") == 2) {
			if (!holdingSeed && seedsInCrate > 0) {
				holdingSeed = true;
				seedsInCrate--;
			}
		} else {
			FlagHandler.SetItem ("carryingBasket", 1);
		}
	}
}
