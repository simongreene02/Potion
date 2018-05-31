using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingSeed = false;
	public GameObject[] unplantedSeeds;
	private int seedsInCrate = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < unplantedSeeds.Length; i++) {
			unplantedSeeds[i].SetActive (i < seedsInCrate);
		}
	}

	public void OnBeingClicked() {
		if (!holdingSeed && seedsInCrate > 0) {
			holdingSeed = true;
			seedsInCrate--;
		}
	}

	public void setSeedsInCrate(int s) {
		seedsInCrate = s;
	}
}
