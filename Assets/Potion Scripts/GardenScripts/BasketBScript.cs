using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingSeed = false;
	public static bool plantingSeeds = true;
	public GameObject[] unplantedSeeds;
	public GameObject[] unplantedSeedCores;
	private int seedsInCrate;
	public GameObject miniBasket;
	public LightRotationScript lightRotationScript;
	public TicketToTheOceanScript ticketToTheOceanScript;

	// Use this for initialization
	void Start () {
		plantingSeeds = true;
		seedsInCrate = unplantedSeeds.Length;
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

		if (plantingSeeds && !holdingSeed && seedsInCrate <= 0) {
			lightRotationScript.enabled = true;
			plantingSeeds = false;
		}
	}

	public void OnBeingClicked() {
		print (plantingSeeds + " " + seedsInCrate + " " + holdingSeed);
		if (FlagHandler.GetItem ("character") == 2) {
			if (plantingSeeds) {
				if (!holdingSeed && seedsInCrate > 0) {
					print ("Holding Seed.");
					holdingSeed = true;
					seedsInCrate--;
					for (int i = 0; i < unplantedSeeds.Length; i++) {
						unplantedSeeds [i].SetActive (i < seedsInCrate);
					}
				}
			} else {
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
				if (seedsInCrate >= 16) {
					FlagHandler.SetItem ("basketState", 2);
					ticketToTheOceanScript.Activate ();
				}
			}
		} else {
			FlagHandler.SetItem ("carryingBasket", 1);
		}
	}
}
