using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour, ActivateOnClickScript {

	public static bool holdingFruit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagHandler.ContainsKey ("basketState") && FlagHandler.GetItem ("basketState") != 0) {
			this.gameObject.SetActive (false);
		}
	}

	public void OnBeingClicked() {
		if (!holdingFruit) {
			holdingFruit = true;
			this.gameObject.SetActive (false);
		}
	}
}
