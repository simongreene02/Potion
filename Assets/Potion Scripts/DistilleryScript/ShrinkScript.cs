using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShrinkScript : MonoBehaviour, ActivateOnClickScript {

	public Vector3 finalPosition;
	public GameObject player;
	public Image fadeToBlack;

	private bool shrinking;
	private float progress = 0f;

	// Update is called once per frame
	void Update () {
		if (shrinking) {
			progress = progress + (Time.deltaTime / 3);
			if (progress >= 1f) {
				progress = 1f;
				shrinking = false;
				player.transform.position = finalPosition;
			}
			player.transform.localScale = new Vector3 ((2 - progress) / 2, (2 - progress) / 2, (2 - progress) / 2);
			fadeToBlack.color = new Color (fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, progress);
		} else {
			if (progress > 0f) {
				progress = progress - (Time.deltaTime / 3);
				if (progress < 0f) {
					progress = 0f;
				}
				player.transform.localScale = new Vector3 ((2 - progress) / 2, (2 - progress) / 2, (2 - progress) / 2);
				fadeToBlack.color = new Color (fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, progress);
			}
		}
	}

	public void OnBeingClicked () {
		shrinking = true;
	}
}
