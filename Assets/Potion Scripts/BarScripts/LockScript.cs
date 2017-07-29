using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour {

	public NecklaceScript necklaceScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (necklaceScript.state == 2 && other.gameObject.tag == "Player") {
			necklaceScript.state++;
			necklaceScript.point = this.gameObject;
			necklaceScript.gameObject.transform.position = this.gameObject.transform.position;
			necklaceScript.gameObject.transform.rotation = this.gameObject.transform.rotation;
		}
	}
}
