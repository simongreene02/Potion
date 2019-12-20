using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBarScript : MonoBehaviour {

	public TicketToTheOceanScript ticketToTheOceanScript;

	// Use this for initialization
	void Start () {
		if (FlagHandler.GetItem ("character") == 0) {
			ticketToTheOceanScript.Activate();
			FlagHandler.SetItem ("barActivated", 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
