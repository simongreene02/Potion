using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingSeed = false;
	public GameObject[] unplantedSeeds;
	private int seedsInCrate;

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
	}

	public void OnBeingClicked() {
		if (!holdingSeed && seedsInCrate > 0) {
			holdingSeed = true;
			seedsInCrate--;
		}
	}
}
