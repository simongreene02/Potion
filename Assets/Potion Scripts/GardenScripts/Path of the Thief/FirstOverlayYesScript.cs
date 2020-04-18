using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOverlayYesScript : MonoBehaviour, ActivateOnClickScript {
	public GameObject overlay1;
	public GameObject overlay2;

	// Use this for initialization
	void Start () {
		overlay2.SetActive (false);
	}

	public void OnBeingClicked() {
		overlay1.SetActive (false);
		overlay2.SetActive (true); 
	}
}
