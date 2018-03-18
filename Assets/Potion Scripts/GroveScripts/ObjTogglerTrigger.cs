using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTogglerTrigger : MonoBehaviour {

	public GameObject[] objsToAppear;
	public GameObject[] objsToDisappear;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter() {
		for (int i = 0; i < objsToAppear.Length; i++) {
			objsToAppear [i].SetActive (true);
		}
		for (int i = 0; i < objsToDisappear.Length; i++) {
			objsToDisappear [i].SetActive (false);
		}
	}

}
