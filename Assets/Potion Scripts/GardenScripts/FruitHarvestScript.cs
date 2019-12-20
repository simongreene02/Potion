using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitHarvestScript : MonoBehaviour, ActivateOnClickScript {

	public LightRotationScript lightRotation;
	public GameObject[] topObjects;
	public float riseTime = 1.0f;
	public int centerRiseAmount = 5;
	public int topRiseAmount = 10;
	private bool isRising;
	private bool isRipened;
	private float currentRiseTime;
	public static bool holdingFruit = false;

	void OnSunCycle() {
		isRising = true;
	}

	void OnEnable() {
		isRising = false;
		isRipened = false;
		lightRotation.OnRotationCompleted += OnSunCycle;
	}

	void OnDisable() {
		lightRotation.OnRotationCompleted -= OnSunCycle;
	}

	void Update() {
		if (isRising) {
			currentRiseTime += Time.deltaTime;
			foreach (GameObject obj in topObjects) {
				obj.transform.position = obj.transform.position + (Vector3.up * (topRiseAmount / riseTime * Time.deltaTime));
			}
			gameObject.transform.position = gameObject.transform.position + (Vector3.up * (centerRiseAmount / riseTime * Time.deltaTime));
			if (currentRiseTime >= riseTime) {
				isRising = false;
				isRipened = true;
			}
		}
	}

	public void OnBeingClicked() {
		if (!holdingFruit && isRipened) {
			holdingFruit = true;
			this.gameObject.SetActive (false);
		}
	}
}
