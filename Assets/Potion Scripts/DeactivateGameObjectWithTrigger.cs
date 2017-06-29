using UnityEngine;
using System.Collections;

public class DeactivateGameObjectWithTrigger : MonoBehaviour {

    public GameObject ObjectName;

    void OnTriggerEnter(Collider other)
    {
        print("GameObject Deactivated");
        ObjectName.SetActive(false);
    }
}