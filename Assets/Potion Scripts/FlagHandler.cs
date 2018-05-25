using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FlagHandler : MonoBehaviour {

	private Dictionary<string, Object> flags = new Dictionary<string, Object> ();
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
			JsonUtility.FromJsonOverwrite (reader.ReadToEnd (), this);
			reader.Close ();
		} else {
			StreamWriter sw = File.CreateText("flags.json");
			sw.Write (JsonUtility.ToJson (this));
			sw.Close ();
		}
		print (SceneManager.GetActiveScene ().name);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void SetItem(string key, Object value) {
		mainInstance.flags[key] = value;
	}

	public static bool ContainsKey(string key) {
		return mainInstance.flags.ContainsKey (key);
	}

	public static Object GetItem(string key) {
		return mainInstance.flags[key];
	}

	public static List<string> GetKeys() {
		return new List<string>(mainInstance.flags.Keys);
	}

	public static void ChangeScene(string sceneName) {
		StreamWriter sw = new StreamWriter ("flags.json", false);
		sw.Write (JsonUtility.ToJson (mainInstance));
		sw.Close ();
		SceneManager.LoadScene (sceneName);
	}
		
}
