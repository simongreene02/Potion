using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBasketScript : MonoBehaviour {
	public GameObject childObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		childObject.SetActive (FlagHandler.ContainsKey ("carryingBasket") && FlagHandler.GetItem ("carryingBasket") == 1);
	}
}
