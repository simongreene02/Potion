using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject uiPanel;

	// Use this for initialization
	void Start () {
		uiPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		uiPanel.SetActive(Input.GetKey (KeyCode.Tab));
	}
}
