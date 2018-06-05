using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCabinScript : MonoBehaviour {

	private float timer = 0.0f;
	private bool timerActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timerActive) {
			timer += Time.deltaTime;
		}
		if (timer >= 5) {
			FlagHandler.ChangeScene ("Potion Scenes/Potion - Cabin v1.6");
		}
	}

	void OnTriggerEnter() {
		timerActive = true;
	}
}
