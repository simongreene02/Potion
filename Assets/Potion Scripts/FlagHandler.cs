using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FlagHandler : MonoBehaviour {

	//public SerializableDictionary<string, int> flags = new SerializableDictionary<string, int> ();
	public Dictionary<string, int> flags = new Dictionary<string, int> ();
	private static FlagHandler mainInstance = null;

	// Use this for initialization
	void Awake () {
		if (mainInstance == null) {
			DontDestroyOnLoad (this);
			mainInstance = this;
		} else {
			Destroy (this);
		}
	}

	public static void SetItem(string key, int value) {
		if (mainInstance.flags.ContainsKey (key)) {
			mainInstance.flags [key] = value;
		} else {
			mainInstance.flags.Add (key, value);
		}
	}

	public static bool ContainsKey(string key) {
		return mainInstance.flags.ContainsKey (key);
	}

	public static int GetItem(string key) {
		return mainInstance.flags[key];
	}

	public static List<string> GetKeys() {
		return new List<string>(mainInstance.flags.Keys);
	}

	public static void ChangeScene(string sceneName) {
		/*StreamWriter sw;
		if (File.Exists ("flags.json")) {
			sw = new StreamWriter ("flags.json", false);
		} else {
			sw = File.CreateText("flags.json");
		}
		mainInstance.flags.OnBeforeSerialize ();
		sw.Write (JsonUtility.ToJson (mainInstance.flags));
		sw.Close ();*/
		foreach (string flag in mainInstance.flags.Keys) {
			print (flag + ": " + mainInstance.flags[flag]);
		}
		SceneManager.LoadScene (sceneName);
	}
		
}
