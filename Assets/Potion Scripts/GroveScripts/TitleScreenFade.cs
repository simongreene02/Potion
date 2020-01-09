using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenFade : MonoBehaviour {
	public Image titleScreen;
	public Image fadeToWhite;
	public MonoBehaviour firstPersonScript;

	private float alpha = 0f;
	private bool phaseTwo = false;

	// Use this for initialization
	void Start () {
		firstPersonScript.enabled = false;
		titleScreen.enabled = true;
		fadeToWhite.color = new Color (1f, 1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!phaseTwo) {
			alpha += Time.deltaTime / 10;
			if (alpha >= 1) {
				alpha = 1f;
				phaseTwo = true;
				titleScreen.enabled = false;
				firstPersonScript.enabled = true;
			}
		} else {
			alpha -= Time.deltaTime / 10;
			if (alpha <= 0) {
				alpha = 0f;
				fadeToWhite.color = new Color (1f, 1f, 1f, 0f);
				this.enabled = false;
			}
		}
		fadeToWhite.color = new Color (1f, 1f, 1f, alpha);
	}
}
