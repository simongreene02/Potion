using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalystScript : MonoBehaviour, ActivateOnClickScript {

	public GameObject player;
	public Vector3 teleportPosition;
	public GameObject miniCatalyst;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeingClicked() {
		player.transform.position = teleportPosition;
		miniCatalyst.SetActive (true);
	}
}
