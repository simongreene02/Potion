using UnityEngine;
using System.Collections;

public class ActivateGravityWithTrigger : MonoBehaviour {
	public Rigidbody rigidbody;
    public GameObject desigCollider;


    void OnTriggerEnter(Collider desigCollider) {
		{
			print ("Triggered!");
			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
			//gameObject.GetComponent<AudioSource>().Play();
		}
	}
}