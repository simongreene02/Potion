using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnteranceScript : MonoBehaviour {
	public GameObject player;
	public Vector3 specialPosition;

	// Use this for initialization
	void Start () {
		if (FlagHandler.ContainsKey ("distilleryFallingEnterance") && FlagHandler.GetItem ("distilleryFallingEnterance") == 1) {
			FlagHandler.SetItem ("distilleryFallingEnterance", 0);
			player.transform.position = specialPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
