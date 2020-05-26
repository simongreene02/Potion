using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScript : MonoBehaviour, ActivateOnClickScript {

	public Image overlay;

	public void OnBeingClicked() {
		overlay.enabled = !overlay.enabled;
	}
}
