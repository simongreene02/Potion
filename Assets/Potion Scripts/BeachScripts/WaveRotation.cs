using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRotation : MonoBehaviour {

	private float rotationAmount = 0f;
	public double secondsPerRotation = 2;
	public double circleLength = 1.0;
	public double initialAngle;

	// Use this for initialization
	void Start () {
		rotationAmount = (float) initialAngle / 180;
		this.gameObject.transform.position += new Vector3 ((float) (circleLength * Mathf.Sin (Mathf.PI * rotationAmount)), (float) (circleLength * Mathf.Cos (Mathf.PI * rotationAmount)), 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position -= new Vector3 ((float) (circleLength * Mathf.Sin (Mathf.PI * rotationAmount)), (float) (circleLength * Mathf.Cos (Mathf.PI * rotationAmount)), 0);
		rotationAmount += (float) (2 * Time.deltaTime / secondsPerRotation);
		this.gameObject.transform.position += new Vector3 ((float) (circleLength * Mathf.Sin (Mathf.PI * rotationAmount)), (float) (circleLength * Mathf.Cos (Mathf.PI * rotationAmount)), 0);
	}
}
