using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardHandler : MonoBehaviour {

	public int drinkThreshold;
	public static int necklaceAppearThreshold = 7;
	public DrinkScript drinkScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = (drinkScript.drinksDrunk >= drinkThreshold && drinkScript.drinksDrunk < necklaceAppearThreshold);
	}
}
