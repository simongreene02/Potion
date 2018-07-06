using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingNowhereScript : MonoBehaviour, ActivateOnClickScript {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		FlagHandler.SetItem ("carryingBasket", 0);
		FlagHandler.ChangeScene ("Potion - Cabin v1.6");
	}
}
