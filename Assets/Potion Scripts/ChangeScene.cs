using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, ActivateOnClickScript {
	public int character;
	public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		if (character >= 0 && character <= 4) {
			FlagHandler.SetItem ("character", character);
		}
		FlagHandler.ChangeScene (sceneName);
	}
}
