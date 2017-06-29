using UnityEngine;
using System.Collections;

public class MoveObjTwrdOnTrigEnter : MonoBehaviour {
	
	bool CallUpdate;

    public GameObject ObjectName;
    public Transform EndPositionGO;
	public float Speed;
    public MoveObjTwrdOnTrigExit doorCloseScript;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Object Entered the Trigger");
        CallUpdate = true;
        doorCloseScript.setCallUpdate(false);
    }
	
	void Update () {
		if ((CallUpdate) && (ObjectName != null)) {
			ObjectName.transform.position = Vector3.MoveTowards (ObjectName.transform.position, EndPositionGO.position, Speed * Time.deltaTime);
        }
      }

    public void setCallUpdate(bool input)
    {
        CallUpdate = input;
    }
}