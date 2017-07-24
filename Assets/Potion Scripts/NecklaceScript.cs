using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceScript : MonoBehaviour {

	private int state;
	public Vector3 appearPosition;
	public GameObject player;
	public GameObject point;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 2) {
			this.gameObject.transform.position = point.transform.position;
			this.gameObject.transform.rotation = point.transform.rotation;
		}
	}

	public void BringNecklaceToTable() {
		if (state == 0) {
			state++;
			this.gameObject.transform.position = appearPosition;
			print (state);
		}
	}

	void OnTriggerEnter(Collider other) {
		print (other);
		if (state == 1 && other.gameObject.tag == "Player") {
			state++;
		} else if (state == 2 && other.gameObject.tag == "LockObject") {
			state++;
			this.gameObject.transform.position = other.gameObject.transform.position;
			this.gameObject.transform.rotation = other.gameObject.transform.rotation;
		}
	}
}
