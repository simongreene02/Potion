using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardHandler : MonoBehaviour {

	public int drinkThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = (DrinkScript.drinksDrunk >= drinkThreshold);
	}
}
