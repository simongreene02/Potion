using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkHandlerScript : MonoBehaviour {

	public GameObject[] drinkList;
	public DrinkOrderScript orderScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < drinkList.GetLength(0); i++) {
			drinkList [i].active = (DrinkScript.drinksDrunk == i);
			if (DrinkScript.drinksDrunk == i) {
				orderScript.drinkScript = drinkList [i].GetComponent<DrinkScript>() as DrinkScript;
			}
		}
	}
}
