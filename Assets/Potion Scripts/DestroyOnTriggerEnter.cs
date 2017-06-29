using UnityEngine;
using System.Collections;

public class DestroyOnTriggerEnter : MonoBehaviour {

    public GameObject ObjectName;

    void OnTriggerEnter(Collider other)
    {
        Destroy(ObjectName);
        //gameObject.GetComponent<AudioSource>().Play();
    }
}