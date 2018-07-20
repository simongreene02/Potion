using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketToTheOceanScript : MonoBehaviour {

	public Image ticket;
	public Image fadeToBlack;
	public int character;
	private bool fading = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			fadeToBlack.color = new Color (fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, fadeToBlack.color.a + (Time.deltaTime / 10));
			if (fadeToBlack.color.a >= 1) {
				fading = false;
				//set character location flag to beach
				FlagHandler.ChangeScene("Potion Scenes/Potion - Cabin v1.6");
			}
		}
	}

	public void Activate() {
		ticket.color = new Color (1, 1, 1, 1);
		fading = true;
	}
}
