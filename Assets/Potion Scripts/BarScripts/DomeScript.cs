using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DomeScript : MonoBehaviour {
	public GameObject player;
	public int sceneChangeThreshold = -1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			StartCoroutine (checkHasFallen());
		}
	}

	IEnumerator checkHasFallen() {
		yield return null;
		while (player.transform.position.y > sceneChangeThreshold) {

			yield return null;
			
		}
		FlagHandler.SetItem ("distilleryFallingEnterance", 1);
		FlagHandler.SetItem ("charmInDistillery", 1);
		FlagHandler.SetItem ("char" + ((int) PlayableCharacters.CHARM) + "Location", (int) SceneIDs.DISTILLERY);
		SceneManager.LoadScene("Potion Scenes/Potion - Distillery v2");
		yield return null;
	}
}
