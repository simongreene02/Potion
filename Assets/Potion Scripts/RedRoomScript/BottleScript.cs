using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottleScript : MonoBehaviour, ActivateOnClickScript {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		FlagHandler.SetItem ("carryingBottle", 1);
		SceneManager.LoadScene("Potion - Distillery v2");
	}
}
