using UnityEngine;
using System.Collections;

public class DestroyTaggedOnTrigEnt : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Special")
            Debug.Log("Special object entered the trigger");
            Destroy(other.gameObject);
            //gameObject.GetComponent<AudioSource>().Play();
    }
}