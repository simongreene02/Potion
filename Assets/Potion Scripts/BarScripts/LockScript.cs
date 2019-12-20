using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LockScript : MonoBehaviour {

	public NecklaceScript necklaceScript;
	private PlayableDirector director;

	// Use this for initialization
	void Start () {
		director = GetComponentInParent<PlayableDirector> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (necklaceScript.state == 2 && other.gameObject.tag == "Player") {
			necklaceScript.state++;
			necklaceScript.point = this.gameObject;
			necklaceScript.gameObject.transform.position = this.gameObject.transform.position;
			necklaceScript.gameObject.transform.rotation = this.gameObject.transform.rotation;
			necklaceScript.transform.SetParent (this.transform);
			director.Play ();
		}
	}
}
