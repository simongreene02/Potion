using UnityEngine;
using System.Collections;

public class DestroyCloneOnTriggerEnter : MonoBehaviour {

    public GameObject ObjectName;
    public InstantiateAtDesigPos cloneScript;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the Face Trigger");
        Destroy(cloneScript.PrefabClone);
        cloneScript.canSpawn = true;


        //DestroyImmediate(this.ObjectName, true);
        //gameObject.GetComponent<AudioSource>().Play();
    }
}