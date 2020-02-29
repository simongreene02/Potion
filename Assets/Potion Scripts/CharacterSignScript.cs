using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSignScript : MonoBehaviour {
	private bool TurnOffAfterFirstFrame = true;

	public GameObject thiefSign;
	public GameObject alchemistSign;
	public GameObject gardenerSign;
	public GameObject charmSign;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagHandler.ContainsKey ("character")) {
			if (thiefSign != null) {
				thiefSign.SetActive (FlagHandler.GetItem ("character") == 0);
			}
			if (alchemistSign != null) {
				alchemistSign.SetActive (FlagHandler.GetItem ("character") == 1);
			}
			if (gardenerSign != null) {
				gardenerSign.SetActive (FlagHandler.GetItem ("character") == 2);
			}
			if (charmSign != null) {
				charmSign.SetActive (FlagHandler.GetItem ("character") == 3);
			}
		}
		if (TurnOffAfterFirstFrame) {
			this.enabled = false;
		}
	}
}
