using UnityEngine;
using System.Collections;

public class ActivateGameObjectWithTrigger : MonoBehaviour {

    public GameObject ObjectName;

    void OnTriggerEnter(Collider other)
    {
        print("GameObject Activated");
        ObjectName.SetActive(true);
    }
}