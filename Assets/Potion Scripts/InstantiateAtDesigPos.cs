using UnityEngine;
using System.Collections;

public class InstantiateAtDesigPos : MonoBehaviour {

    public GameObject ObjToInstantiate;
    public bool canSpawn = true;
    public Vector3 objectPlacementPosition;
    public Quaternion objectPlacementRotation;
    public GameObject PrefabClone;
    

    void OnTriggerEnter(Collider other)
    {
        if (canSpawn == true)
        {

            canSpawn = false;
            PrefabClone = (GameObject) Instantiate(ObjToInstantiate, objectPlacementPosition, objectPlacementRotation);
        }
    }
}
