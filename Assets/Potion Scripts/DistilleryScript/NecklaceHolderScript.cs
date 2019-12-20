using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecklaceHolderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FlagHandler.SetItem ("distilleryNecklaceAppear", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagHandler.GetItem ("character") == 3 && FlagHandler.GetItem ("necklaceInStill") == 0) {
			FlagHandler.SetItem ("distilleryNecklaceAppear", 1);
		} else {
			FlagHandler.SetItem ("distilleryNecklaceAppear", 0);
		}
	}
}
