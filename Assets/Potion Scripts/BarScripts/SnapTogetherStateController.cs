using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTogetherStateController : MonoBehaviour {

	public Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator.GetBool ("snapTogetherTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
