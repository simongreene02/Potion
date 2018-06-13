using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBasketScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagHandler.ContainsKey ("carryingBasket")) {
			this.gameObject.GetComponent<MeshRenderer>().enabled = FlagHandler.GetItem ("carryingBasket") == 0;
		}
	}
}
