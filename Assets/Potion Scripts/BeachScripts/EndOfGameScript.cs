using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameScript : MonoBehaviour {

	public Image endOfLevelOne;
	public Image fadeToBlack;
	private bool fading = false;
	private float timeToFade1 = 10f;
	private float timeToFade2 = 20f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (fading) {
			endOfLevelOne.color = new Color (endOfLevelOne.color.r, endOfLevelOne.color.g, endOfLevelOne.color.b, endOfLevelOne.color.a + (Time.deltaTime / timeToFade1));
			if (endOfLevelOne.color.a >= 1) {
				endOfLevelOne.color = new Color (endOfLevelOne.color.r, endOfLevelOne.color.g, endOfLevelOne.color.b, 1f);
				fadeToBlack.color = new Color (fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, fadeToBlack.color.a + (Time.deltaTime / timeToFade2));
				if (fadeToBlack.color.a >= 1) {
					fading = false;
					fadeToBlack.color = new Color (fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, 1f);
				}
			}
		}
	}

	public void OnTriggerEnter(Collider o) {
		fading = true;
	}
}
