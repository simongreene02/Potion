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
			this.transform.position = attachObject.transform.rotation * new Vector3 (0, 0, 1) + attachObject.transform.position;
			this.transform.parent = attachObject.transform;
			print (state);
		}
	}
}
