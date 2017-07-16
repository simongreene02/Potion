using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceScript : MonoBehaviour {

	private int state;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AttachNecklaceToPlayer() {
		if (state == 0) {
			state++;
		}
	}
}
