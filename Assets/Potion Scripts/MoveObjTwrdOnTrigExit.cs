using UnityEngine;
using System.Collections;

public class MoveObjTwrdOnTrigExit : MonoBehaviour {
	
	bool CallUpdate;

    public GameObject ObjectName;
    public Transform EndPositionGO;
	public float Speed;
    public MoveObjTwrdOnTrigEnter doorOpenScript;

    void OnTriggerExit(Collider other) {
        Debug.Log("Object Exited the Trigger");
        CallUpdate = true;
        doorOpenScript.setCallUpdate(false);
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