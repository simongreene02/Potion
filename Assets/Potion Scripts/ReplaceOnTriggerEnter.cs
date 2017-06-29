using UnityEngine;
using System.Collections;

public class ReplaceOnTriggerEnter : MonoBehaviour {

    public GameObject Replacement;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(Replacement);
    }
}