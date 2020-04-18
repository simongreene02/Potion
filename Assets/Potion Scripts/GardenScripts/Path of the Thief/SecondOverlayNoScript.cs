using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondOverlayNoScript : MonoBehaviour, ActivateOnClickScript {
	public GameObject overlay2;

	// Use this for initialization
	void Start () {
	}

	public void OnBeingClicked() {
		overlay2.SetActive (false);
	}
}
