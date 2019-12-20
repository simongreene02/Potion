using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingNowhereScript : MonoBehaviour, ActivateOnClickScript {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		FlagHandler.SetItem ("carryingBasket", 0);
		SceneManager.LoadScene("Potion - Cabin v1.6");
	}
}
