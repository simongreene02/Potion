using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnFlagValue : MonoBehaviour {

	public string flag;
	public bool isFalse;
	public ComparisonOps comparisonOperator;
	public int value;

	public MeshRenderer[] meshRenderers; 
	public Collider[] colliders; 
	public bool lastFlagValue = true;

	// Use this for initialization
	void Start () {
		meshRenderers = GetComponentsInChildren<MeshRenderer>();
		colliders = GetComponentsInChildren<Collider>();
		ToggleObjects (lastFlagValue);
	}
	
	// Update is called once per frame
	void Update () {
		if (lastFlagValue != checkFlagValue ()) {
			lastFlagValue = checkFlagValue ();
			ToggleObjects (lastFlagValue);
		}
	}

	private bool checkFlagValue () {
		if (FlagHandler.ContainsKey (flag)) {
			return isFalse ^ performOperation (FlagHandler.GetItem (flag), comparisonOperator, value);
		} else {
			return isFalse;
		}
	}

	private bool performOperation(int a, ComparisonOps op, int b) {
		if (op == ComparisonOps.EQUAL_TO) {
			return a == b;
		}
		if (op == ComparisonOps.GREATER_THAN) {
			return a > b;
		}
		if (op == ComparisonOps.LESS_THAN) {
			return a < b;
		}
		return false;
	}

	private void ToggleObjects(bool value) {
		foreach (var render in meshRenderers) {
			render.enabled = value;
		}
		foreach (var col in colliders) {
			col.enabled = value;
		}
	}

	public enum ComparisonOps {
		EQUAL_TO, 
		GREATER_THAN, 
		LESS_THAN
	}
}
