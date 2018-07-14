using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBasketScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = FlagHandler.ContainsKey("carryingBasket") && FlagHandler.GetItem ("carryingBasket") == 1;
	}
}
