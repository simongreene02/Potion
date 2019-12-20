using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBarScript : MonoBehaviour, ActivateOnClickScript {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked () {
		print (FlagHandler.GetItem ("basketState"));
		Vector3 thisPosition = gameObject.transform.position;
		Vector3 playerPosition = player.transform.position;

		if (Mathf.Sqrt (Mathf.Pow (thisPosition.x - playerPosition.x, 2) + Mathf.Pow (thisPosition.y - playerPosition.y, 2) + Mathf.Pow (thisPosition.z - playerPosition.z, 2)) <= 20) {
			if (FlagHandler.ContainsKey ("basketState") && FlagHandler.GetItem ("basketState") == 2 && FlagHandler.ContainsKey ("carryingBasket") && FlagHandler.GetItem ("carryingBasket") == 1) {
				FlagHandler.SetItem ("char" + FlagHandler.GetItem ("character") + "Location", (int) SceneIDs.BAR);
				SceneManager.LoadScene ("Potion - Bar- drinking contest");
			}
		}
	}
}
