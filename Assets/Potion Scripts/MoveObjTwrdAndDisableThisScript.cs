using UnityEngine;
using System.Collections;

public class MoveObjTwrdAndDisableThisScript : MonoBehaviour
{

    bool CallUpdate;

    public GameObject ObjectName;
    public Transform EndPositionGO;
    public float Speed;
    private bool scriptHasActivated = false;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the Trigger");

        if (!scriptHasActivated)
        {
            scriptHasActivated = true;
            CallUpdate = true;
        }
    }

    void Update()
    {
        if ((CallUpdate) && (ObjectName != null))
        {
            ObjectName.transform.position = Vector3.MoveTowards(ObjectName.transform.position, EndPositionGO.position, Speed * Time.deltaTime);
            if (ObjectName.transform.position == EndPositionGO.transform.position)
            {
                CallUpdate = false;
            }
        }
    }
}