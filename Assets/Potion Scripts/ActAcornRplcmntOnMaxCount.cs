using UnityEngine;
using System.Collections;

public class ActAcornRplcmntOnMaxCount : MonoBehaviour {

    public GameObject objToActivate;
    public GameObject[] objsToDeactivate;

    void Update()
    {
        int x = AcornPort.acornPortCount;
        if(x == 24){
            objToActivate.SetActive(true);
            foreach (GameObject _obj in objsToDeactivate)
            {
                _obj.SetActive(false);
            }
        }
    }
}