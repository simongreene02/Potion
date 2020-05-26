using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondOverlayNoScript : MonoBehaviour {
	public GameObject overlay2;
	public GameObject interfaceTint;

	// Use this for initialization
	void Start () {
	}

	public void ClickNoButton() {
		overlay2.SetActive (false);
		interfaceTint.SetActive (false);
	}
}
