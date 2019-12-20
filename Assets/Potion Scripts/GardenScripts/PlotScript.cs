using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotScript : MonoBehaviour, ActivateOnClickScript {

	public GameObject plantedSeed;

	// Use this for initialization
	void Start () {
		plantedSeed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		if (BasketBScript.holdingSeed && !plantedSeed.activeInHierarchy) {
			print ("Not Holding Seed.");
			BasketBScript.holdingSeed = false;
			plantedSeed.SetActive (true);
		}
	}
}
