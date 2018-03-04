using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHandlerScript : MonoBehaviour {

	public GameObject[] drinkList;
	public DrinkOrderScript orderScript;
	public BackAndForthScript buttonMover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < drinkList.Length; i++) {
			drinkList [i].active = (DrinkScript.drinksDrunk == i);
		}
		if (DrinkScript.drinksDrunk < drinkList.Length) {
			orderScript.drinkScript = drinkList [DrinkScript.drinksDrunk].GetComponent<DrinkScript> () as DrinkScript;
		}
		if (DrinkScript.drinksDrunk == 1) {
			buttonMover.enabled = true;
		}
		if (DrinkScript.drinksDrunk == 6) {
			buttonMover.enabled = false;
		}
	}
}
