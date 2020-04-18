using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickHandlerUI : MonoBehaviour {
	private static Transform objectPointingAt;
	private static bool raycastChecked;

	private GraphicRaycaster raycaster;
	private ClickHandler[] childScripts;

	// Use this for initialization
	void Start () {
		raycaster = GetComponent<GraphicRaycaster> ();
		childScripts = new ClickHandler[this.gameObject.transform.childCount];
		for (int i = 0; i < childScripts.Length; i++) {
			if (this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandler> () == null) {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.AddComponent<ClickHandler> () as ClickHandler;
			} else {
				childScripts [i] = this.gameObject.transform.GetChild (i).gameObject.GetComponent<ClickHandler> () as ClickHandler;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (raycastChecked) {
			objectPointingAt = null;
			raycastChecked = false;
			print ("Clearing raycast data.");
		}
		//print (this.gameObject.GetComponent (typeof(ActivateOnClickScript)));
		if (this.gameObject.GetComponent(typeof(ActivateOnClickScript)) != null) { //this.clickScript != null) {
			if (Input.GetMouseButtonDown (0) && IsMouseOn()) {
				(this.gameObject.GetComponent(typeof(ActivateOnClickScript)) as ActivateOnClickScript).OnBeingClicked ();
				print ("click");
			}
		}
	}

	public bool IsMouseOn() {
		if (!raycastChecked) {
			PointerEventData pointerData = new PointerEventData (EventSystem.current);
			List<RaycastResult> results = new List<RaycastResult>();
			pointerData.position = Input.mousePosition;
			this.raycaster.Raycast (pointerData, results);
			print ("Setting raycast data.");
			raycastChecked = true;  
			if (results.Count > 0) {
				objectPointingAt = results[0].gameObject.transform;
				print("Set raycast to " + results[0].gameObject.transform.name);
			}
		}

		//if (objectPointingAt == null) {
		//	return false;
		//}
		if (objectPointingAt == gameObject.transform) {
			return true;
		}
		if (childScripts == null) {
			return false;
		}
		for (int i = 0; i < childScripts.Length; i++) {
			if (childScripts [i].IsMouseOn()) {
				return true;
			}
		}
		return false;
	}
}
