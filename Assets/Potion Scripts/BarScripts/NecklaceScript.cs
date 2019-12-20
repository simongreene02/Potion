using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceScript : MonoBehaviour, ActivateOnClickScript {

	[HideInInspector]
	public int state;
	public Vector3 appearPosition;
	public GameObject point;
	public RugScript rugScript;
	public GameObject emptyNecklace;

	// Use this for initialization
	void Start () {
		BringNecklaceToTable ();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 2) {
			this.gameObject.transform.position = point.transform.position;
			this.gameObject.transform.rotation = point.transform.rotation;
		}
		rugScript.enabled = (state == 2);
	}

	public void BringNecklaceToTable() {
		if (state == 0) {
			state++;
			this.gameObject.transform.position = appearPosition;
			emptyNecklace.SetActive (false);
			print (state);
		}
	}

	public void OnBeingClicked() {
		if (state == 1) {
			state++;
		}
	}
}
