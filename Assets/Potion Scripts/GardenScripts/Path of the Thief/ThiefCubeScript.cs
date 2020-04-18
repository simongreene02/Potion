﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefCubeScript : MonoBehaviour, ActivateOnClickScript {
	public GameObject overlay1;

	// Use this for initialization
	void Start () {
		overlay1.SetActive (false);
	}
	
	public void OnBeingClicked() {
		overlay1.SetActive (true);
		this.gameObject.SetActive (false);
	}
}
