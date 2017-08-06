using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugScript : MonoBehaviour {

	private float location;
	public GameObject panel;
	public Vector3 startPosititon;
	public Vector3 endPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (location >= 1) {
			location = 1;
		} else if (location > 0) {
			location += Time.deltaTime;
		}
		panel.transform.position = new Vector3 (Mathf.Lerp (startPosititon.x, endPosition.x, location), Mathf.Lerp (startPosititon.y, endPosition.y, location), Mathf.Lerp (startPosititon.z, endPosition.z, location));
	}

	void OnColliderEnter(Collider other) {
		if (other.transform.tag == "Player") {
			location += Time.deltaTime;
		}
	}
}
