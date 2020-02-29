using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachCutsceneScript : MonoBehaviour {
	public Material[] charMats;
	public Material[] centerModelMats;
	public float timeToFadeOut;
	public float timeToFadeIn;
	public GameObject cutsceneCamera;
	public GameObject playerCharacter;

	private float opacity = 1f;
	private bool fadingOut = true;

	// Use this for initialization
	void Start () {
		foreach (Material mat in charMats) {
			mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1f);
		}
		foreach (Material mat in centerModelMats) {
			mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0f);
		}
		cutsceneCamera.SetActive(true);
		playerCharacter.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (fadingOut) {
			opacity -= Time.deltaTime / timeToFadeOut;
			if (opacity <= 0) {
				opacity = 0f;
				fadingOut = false;
			}
			foreach (Material mat in charMats) {
				mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, opacity);
			}
		} else {
			opacity += Time.deltaTime / timeToFadeIn;
			if (opacity >= 1) {
				opacity = 1f;
				this.gameObject.SetActive (false);
				cutsceneCamera.SetActive(false);
				playerCharacter.SetActive (true);
			}
			foreach (Material mat in centerModelMats) {
				mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, opacity);
			}
		}
	}
}
