using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachTeleportScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (FlagHandler.ContainsKey("char0AtBeach") && FlagHandler.ContainsKey("char1AtBeach") && FlagHandler.ContainsKey("char2AtBeach") && FlagHandler.ContainsKey("char3AtBeach") && FlagHandler.GetItem ("char0AtBeach") == 1 && FlagHandler.GetItem ("char1AtBeach") == 1 && FlagHandler.GetItem ("char2AtBeach") == 1 && FlagHandler.GetItem ("char3AtBeach") == 1) {
			SceneManager.LoadScene("Potion Scenes/Potion - Beach");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
