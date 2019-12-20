using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRoomRugScript : MonoBehaviour {

	private float location;
	public GameObject painting;
	public Vector3 startPosititon;
	public Vector3 endPosition;
	public int awokenFrames = 0;


	// Use this for initialization
	void Start () {
		painting.transform.position = new Vector3 (Mathf.Lerp (startPosititon.x, endPosition.x, 0), Mathf.Lerp (startPosititon.y, endPosition.y, 0), Mathf.Lerp (startPosititon.z, endPosition.z, 0));
	}

	// Update is called once per frame
	void Update () {
		if (location >= 1) {
			location = 1;
		} else if (location > 0) {
			location += Time.deltaTime;
		}
		painting.transform.position = new Vector3 (Mathf.Lerp (startPosititon.x, endPosition.x, location), Mathf.Lerp (startPosititon.y, endPosition.y, location), Mathf.Lerp (startPosititon.z, endPosition.z, location));
		awokenFrames++;
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Player") {
			if (awokenFrames > 1) {
				location += Time.deltaTime;
			}
		}
		print (location);
	}
}
