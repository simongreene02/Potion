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
		print ("Collided");
		if (state == 1 && other.gameObject.tag == "Player") {
			state++;
		}
		/*
			Vector3 playerPosition = player.transform.position;
			Quaternion playerRotation = player.transform.rotation;
			player.transform.position = Vector3.zero;
			player.transform.rotation = Quaternion.identity;
			this.gameObject.transform.position = Vector3.forward;
			this.gameObject.transform.rotation = Quaternion.identity;
			this.gameObject.transform.SetParent(player.transform);
			player.transform.position = playerPosition;
			player.transform.rotation = playerRotation;
			print (state);
		}
		*/
	}
}
