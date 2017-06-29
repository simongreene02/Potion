using UnityEngine;
using System.Collections;

public class DestroyInstdOnTrigEnt : MonoBehaviour
{

    public GameObject ObjectName;
    private float time = 0.01f;
    private GameObject ClonedObj;

    void OnTriggerEnter(Collider other)
    {
        //if (col.transform.tag == "Projectile")
        {
            Destroy(ClonedObj, time);
        }
    }
}