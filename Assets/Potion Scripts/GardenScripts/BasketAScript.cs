using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketAScript : MonoBehaviour, ActivateOnClickScript {

	public GameObject basketB;
	public GameObject miniBasket;
	public GameObject[] pickedFruitProps;
	private int fruitsInCrate = 0;
	public int fruitPickingThreshold = 9;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!FlagHandler.ContainsKey ("haveFruitsBeenPicked")) {
			FlagHandler.SetItem ("haveFruitsBeenPicked", 0);
		}
		if (fruitsInCrate >= fruitPickingThreshold) {
			FlagHandler.SetItem ("haveFruitsBeenPicked", 1);
		}
		for (int i = 0; i < pickedFruitProps.Length; i++) {
			pickedFruitProps [i].SetActive (i < fruitsInCrate);
		}
		basketB.SetActive (FlagHandler.GetItem ("haveFruitsBeenPicked") == 1 && FlagHandler.GetItem("character") == 0);
		miniBasket.SetActive (FlagHandler.GetItem ("haveFruitsBeenPicked") == 1 && FlagHandler.GetItem("character") == 2);
		this.gameObject.SetActive (FlagHandler.GetItem ("haveFruitsBeenPicked") == 0);
	}

	public void OnBeingClicked() {
		if (FruitScript.holdingFruit) {
			FruitScript.holdingFruit = false;
			fruitsInCrate++;
		}
	}
}
