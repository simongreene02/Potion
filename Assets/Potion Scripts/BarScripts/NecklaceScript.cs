using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceScript : MonoBehaviour {

	[HideInInspector]
	public int state;
	public Vector3 appearPosition;
	public GameObject point;
	public RugScript rugScript;

	// Use this for initialization
	void Start () {
		
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
			print (state);
		}
	}

	void OnTriggerEnter(Collider other) {
		print (other.gameObject.tag);
		if (state == 1 && other.gameObject.tag == "Player") {
			state++;
		}
	}
}
