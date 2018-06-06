using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FlagHandler : MonoBehaviour {

	public SerializableDictionary<string, int> flags = new SerializableDictionary<string, int> ();
	private static FlagHandler mainInstance = null;

	// Use this for initialization
	void Start () {
		if (mainInstance == null) {
			mainInstance = this;
		} else {
			Destroy (this);
		}

		if (SceneManager.GetActiveScene().name == "Potion - Tree Start") {
			if (File.Exists ("flags.json")) {
				File.Delete ("flags.json");
			}
		}
		if (File.Exists ("flags.json")) {
			StreamReader reader = new StreamReader ("flags.json");
			JsonUtility.FromJsonOverwrite (reader.ReadToEnd (), flags);
			flags.OnAfterDeserialize ();
			reader.Close ();
		} else {
			StreamWriter sw = File.CreateText("flags.json");
			flags.OnBeforeSerialize ();
			sw.Write (JsonUtility.ToJson (flags));
			sw.Close ();
		}
		print (SceneManager.GetActiveScene ().name);
	}
	
	// Update is called once per frame
	void Update () {
		
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
		StreamWriter sw;
		if (File.Exists ("flags.json")) {
			sw = new StreamWriter ("flags.json", false);
		} else {
			sw = File.CreateText("flags.json");
		}
		mainInstance.flags.OnBeforeSerialize ();
		sw.Write (JsonUtility.ToJson (mainInstance.flags));
		sw.Close ();
		SceneManager.LoadScene (sceneName);
	}
		
}
