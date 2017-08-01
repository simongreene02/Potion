using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateGround : MonoBehaviour {

	public GameObject player;
	public GameObject tree;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Mathf.Sqrt (Mathf.Pow (player.transform.position.x - tree.transform.position.x, 2) + Mathf.Pow (player.transform.position.z - tree.transform.position.z, 2));
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, 85 - distance / 3, this.gameObject.transform.position.y);
	}
}
