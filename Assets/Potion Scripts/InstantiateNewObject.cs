using UnityEngine;
using System.Collections;

public class InstantiateNewObject : MonoBehaviour {

    public GameObject ObjectToInstantiate;
    private bool hasBeenActivated = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasBeenActivated == false)
        {
            hasBeenActivated = true;
            Instantiate(ObjectToInstantiate, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion());
        }
    }
}
