using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionalChangeScene : MonoBehaviour, ActivateOnClickScript {
	public string flag;
	public bool not;
	public ComparisonOps comparisonOperator;
	public int value;

	public int character;
	public string sceneName;
	public int sceneNumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnBeingClicked () {
		if (not ^ performOperation (FlagHandler.GetItem (flag), comparisonOperator, value)) {
			if (character >= 0 && character <= 4) {
				FlagHandler.SetItem ("character", character);
			}
			FlagHandler.SetItem ("char" + FlagHandler.GetItem ("character") + "Location", sceneNumber);
			SceneManager.LoadScene(sceneName);
		}
	}

	private bool checkFlagValue () {
		if (FlagHandler.ContainsKey (flag)) {
			return not ^ performOperation (FlagHandler.GetItem (flag), comparisonOperator, value);
		} else {
			return not;
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

	public enum ComparisonOps {
		EQUAL_TO, 
		GREATER_THAN, 
		LESS_THAN
	}
}
