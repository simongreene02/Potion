using UnityEngine;
using System.Collections;

public class ObjectPlaceSnap : MonoBehaviour {

    public GameObject gameobject;
    public GameObject staticObject;
    public Vector3 objectPlacementPosition;
    public Quaternion objectPlacementRotation;
    private bool scriptHasActivated = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (!scriptHasActivated) {
            scriptHasActivated = true;
            print("Triggered!");
            Destroy(gameobject);
            Instantiate(staticObject, objectPlacementPosition, objectPlacementRotation);
        }
    }
}