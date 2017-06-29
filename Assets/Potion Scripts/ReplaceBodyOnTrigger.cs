using UnityEngine;
using System.Collections;

public class ReplaceBodyOnTrigger : MonoBehaviour {

    public GameObject ObjToRemove;
    public GameObject Replacement;
    public GameObject TransCollider;

    void OnTriggerEnter(Collider TransCollider)
    {
        ObjToRemove.SetActive(false);
        Replacement.SetActive(true);
    }
}