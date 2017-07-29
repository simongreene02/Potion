using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkScript : MonoBehaviour {

	float state = 2; // 0 = gliding out, 1 = waiting to be drunk, 2 = waiting to be served
	public Vector3 startPosition;
	public Vector3 endPosition;
	public static int drinksDrunk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (state != 2) {
			this.gameObject.transform.position = new Vector3(Mathf.Lerp (startPosition.x, endPosition.x, state), Mathf.Lerp (startPosition.y, endPosition.y, state), Mathf.Lerp (startPosition.z, endPosition.z, state));
		}
		if (state < 1) {
			state += Time.deltaTime / 3;
		}
		if (state > 1 && state != 2) {
			state = 1;
		}
		//this.gameObject.GetComponent<MeshRenderer>().enabled = (state != 2);
	}

	public void OnActivate () {
		if (state == 2) {
			state = 0;
		}
	}

	public void OnBeingClicked () {
		if (state == 1) {
			state = 2;
			drinksDrunk++;
			print (drinksDrunk);
			this.gameObject.transform.position = new Vector3 (0, 0, 0);
		}
	}

	public int getDrinksDrunk() {
		return drinksDrunk;
	}
}
