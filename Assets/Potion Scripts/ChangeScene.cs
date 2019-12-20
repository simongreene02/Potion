using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, ActivateOnClickScript {
	public GameObject player;
	public int character;
	public string sceneName;
	public int sceneNumber;
	public bool useProximity = false;
	public int maxProximity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		Vector3 thisPosition = gameObject.transform.position;
		Vector3 playerPosition = player.transform.position;

		if (!useProximity || Mathf.Sqrt (Mathf.Pow (thisPosition.x - playerPosition.x, 2) + Mathf.Pow (thisPosition.y - playerPosition.y, 2) + Mathf.Pow (thisPosition.z - playerPosition.z, 2)) <= maxProximity) {
			if (character >= 0 && character <= 4) {
				FlagHandler.SetItem ("character", character);
			}
			FlagHandler.SetItem ("char" + FlagHandler.GetItem ("character") + "Location", sceneNumber);
			SceneManager.LoadScene (sceneName);
		}
	}
}
