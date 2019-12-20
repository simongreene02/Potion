using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInitalizer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (!FlagHandler.ContainsKey ("char0Location")) {
			FlagHandler.SetItem ("char0Location", 0);
		}
		if (!FlagHandler.ContainsKey ("char1Location")) {
			FlagHandler.SetItem ("char1Location", 0);
		}
		if (!FlagHandler.ContainsKey ("char2Location")) {
			FlagHandler.SetItem ("char2Location", 0);
		}
		if (!FlagHandler.ContainsKey ("char3Location")) {
			FlagHandler.SetItem ("char3Location", 0);
		}
		this.enabled = false;
	}
}
