using UnityEngine;
using System.Collections;

public class ActivateTaggedGravWithTrigStay : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Special")
            Debug.Log("Special object entered the trigger");
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}