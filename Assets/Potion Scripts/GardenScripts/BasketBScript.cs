using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingSeed = false;
	public static bool plantingSeeds = true;
	public GameObject[] unplantedSeeds;
	public GameObject[] unplantedSeedCores;
	public GameObject[] basketParts;
	private int seedsInCrate;
	private bool partsActivated = false;
	public GameObject miniBasket;
	public LightRotationScript lightRotationScript;
	public TicketToTheOceanScript ticketToTheOceanScript;

	// Use this for initialization
	void Start () {
		holdingSeed = false;
		plantingSeeds = true;
		seedsInCrate = 0;
		if (FlagHandler.GetItem ("character") == 2) {
			foreach (GameObject obj in basketParts) {
				obj.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//for (int i = 0; i < unplantedSeeds.Length; i++) {
		//	unplantedSeeds[i].SetActive (i < seedsInCrate);
		//}

		//print (holdingSeed + " " + seedsInCrate);
		if (FlagHandler.ContainsKey ("carryingBasket")) {
			miniBasket.SetActive (FlagHandler.GetItem ("carryingBasket") != 0);
			this.gameObject.SetActive (FlagHandler.GetItem ("carryingBasket") == 0);
		}

		if (plantingSeeds && !holdingSeed && BasketFruitScript.uncollectedSeeds <= 0) {
			lightRotationScript.enabled = true;
			plantingSeeds = false;
		}

		if (!plantingSeeds && !holdingSeed && BasketFruitScript.uncollectedSeeds <= 0 && !lightRotationScript.enabled && !partsActivated) {
			foreach (GameObject obj in basketParts) {
				obj.SetActive (true);
			}
			partsActivated = true;
			foreach (GameObject obj in unplantedSeedCores) {
				obj.SetActive (false);
				obj.transform.parent = this.gameObject.transform;
			}
		}
	}

	public void OnBeingClicked() {
		print (plantingSeeds + " " + seedsInCrate + " " + holdingSeed);
		if (FlagHandler.GetItem ("character") == 2) {
			//if (plantingSeeds) {
			//	if (!holdingSeed && seedsInCrate > 0) {
			//		print ("Holding Seed.");
			//		holdingSeed = true;
			//		seedsInCrate--;
			//		for (int i = 0; i < unplantedSeeds.Length; i++) {
			//			unplantedSeeds [i].SetActive (i < seedsInCrate);
			//		}
			//	}
			//} else {
			if (!plantingSeeds) {
				if (FruitHarvestScript.holdingFruit) {
					FruitHarvestScript.holdingFruit = false;
					seedsInCrate++;
					for (int i = 0; i < unplantedSeedCores.Length; i++) {
						if (i < seedsInCrate) {
							GameObject plantObject = unplantedSeedCores[i];
							plantObject.SetActive (true);
							while (plantObject.transform.parent != null && plantObject.transform.parent.gameObject != this.gameObject) {
								plantObject = plantObject.transform.parent.gameObject;
								plantObject.SetActive(true);
								if (plantObject.GetComponent<MeshRenderer>() != null) {
									plantObject.GetComponent<MeshRenderer> ().enabled = false;
								}
								foreach (MeshRenderer mesh in plantObject.GetComponentsInChildren<MeshRenderer>()) {
									mesh.enabled = false;
								}
							}
						}
						unplantedSeedCores [i].GetComponent<MeshRenderer> ().enabled = true;
					}
				}
				if (seedsInCrate >= unplantedSeedCores.Length) {
					FlagHandler.SetItem ("basketState", 2);
					ticketToTheOceanScript.Activate ();
				}
			}
		} else {
			FlagHandler.SetItem ("carryingBasket", 1);
		}
	}
}
