using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDistilleryScript : MonoBehaviour {
	public ChangeScene charmChangeScene;

	// Use this for initialization
	void Start () {
		if (FlagHandler.ContainsKey("charmInDistillery") && FlagHandler.GetItem ("charmInDistillery") == 1) {
			charmChangeScene.sceneName = "Potion Scenes/Potion - Distillery v2";
			charmChangeScene.sceneNumber = 4;
		}
	}
}
