using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOverlayNoScript : MonoBehaviour {
	public GameObject overlay1;
	public GameObject overlay2;
	public GameObject interfaceTint;

	// Use this for initialization
	void Start () {
		overlay2.SetActive (false);
	}

	public void NoButtonClick() {
		overlay1.SetActive (false);
		interfaceTint.SetActive (false);
	}
}
