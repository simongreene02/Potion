using UnityEngine;
using System.Collections;

public class DeactivateBoxCollider : MonoBehaviour {

    public GameObject ObjectName;

    void OnTriggerEnter(Collider other)
    {
        print("GameObject Deactivated");
        ObjectName.GetComponent<BoxCollider>().enabled = false;
    }
}