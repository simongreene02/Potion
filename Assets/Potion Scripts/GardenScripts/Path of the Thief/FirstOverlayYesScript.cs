using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOverlayYesScript : MonoBehaviour {
	public GameObject overlay1;
	public GameObject overlay2;

	// Use this for initialization
	void Start () {
		overlay2.SetActive (false);
	}

	public void ClickYesButton() {
		overlay2.SetActive (true); 
		overlay1.SetActive (false);
	}
}
