using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceScript : MonoBehaviour {

	private int state;
	public Vector3 appearPosition;
	public GameObject attachObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void BringNecklaceToTable() {
		if (state == 0) {
			state++;
			this.gameObject.transform.position = appearPosition;
			print (state);
		}
	}

	void OnTriggerEnter(Collider other) {
		print ("Collided");
		if (state == 1 && other.gameObject.tag == "Player") {
			state++;
			Vector3 attachObjectPosition = attachObject.transform.position;
			Quaternion attachObjectRotation = attachObject.transform.rotation;
			attachObject.transform.position = Vector3.zero;
			attachObject.transform.rotation = Quaternion.identity;
			this.gameObject.transform.position = Vector3.forward;
			this.gameObject.transform.rotation = Quaternion.identity;
			this.gameObject.transform.SetParent(attachObject.transform);
			attachObject.transform.position = attachObjectPosition;
			attachObject.transform.rotation = attachObjectRotation;
			print (state);
		}
	}
}
