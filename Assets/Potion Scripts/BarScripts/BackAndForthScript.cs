using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthScript : MonoBehaviour {

	public Vector3 position1;
	public Vector3 position2;
	public float travelTime = 1.0f;
	private float timeRunning;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeRunning += Time.deltaTime;
		if ((timeRunning / travelTime) % 2 < 1) {
			this.gameObject.transform.position = new Vector3 (Mathf.Lerp (position1.x, position2.x, (timeRunning % travelTime) / travelTime), Mathf.Lerp (position1.y, position2.y, (timeRunning % travelTime) / travelTime), Mathf.Lerp (position1.z, position2.z, (timeRunning % travelTime) / travelTime));
		} else {
			this.gameObject.transform.position = new Vector3 (Mathf.Lerp (position2.x, position1.x, (timeRunning % travelTime) / travelTime), Mathf.Lerp (position2.y, position1.y, (timeRunning % travelTime) / travelTime), Mathf.Lerp (position2.z, position1.z, (timeRunning % travelTime) / travelTime));
		}
	}
}
