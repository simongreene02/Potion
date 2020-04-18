using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTestScript : MonoBehaviour {
	public bool isGardener;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FlagHandler.SetItem ("character", (isGardener ? 2 : 0));
		this.enabled = false;
	}
}
