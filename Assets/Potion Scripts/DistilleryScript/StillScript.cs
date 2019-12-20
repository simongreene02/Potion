using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillScript : MonoBehaviour {

	public GameObject necklace;
	public GameObject miniCatalyst;
	public GameObject bottle;
	public TicketToTheOceanScript alchemistTicketToTheOceanScript;
	public TicketToTheOceanScript charmTicketToTheOceanScript;

	// Use this for initialization
	void Start () {
		if (!FlagHandler.ContainsKey("necklaceInStill")) {
			FlagHandler.SetItem ("necklaceInStill", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		GameObject obj = other.gameObject;
		while (obj.transform.parent != null) {
			print (obj);
			if (obj == necklace) {
				FlagHandler.SetItem ("necklaceInStill", 1);
				FlagHandler.SetItem ("stillState", 1);
				necklace.SetActive (false);
			} else if (obj == miniCatalyst) {
				if (FlagHandler.ContainsKey ("stillState") && FlagHandler.GetItem ("stillState") == 1) {
					FlagHandler.SetItem ("stillState", 2);
					alchemistTicketToTheOceanScript.Activate ();
					miniCatalyst.SetActive (false);
				}
			} else if (obj == bottle) {
				if (FlagHandler.ContainsKey ("stillState") && FlagHandler.GetItem ("stillState") == 2) {
					FlagHandler.SetItem ("stillState", 3);
					charmTicketToTheOceanScript.Activate ();
					print ("Charm goes to the ocean.");
					bottle.SetActive (false);
				}
			}
			obj = obj.transform.parent.gameObject;
		}
	}


}
