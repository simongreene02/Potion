using UnityEngine;
using System.Collections;

public class AcornPort : MonoBehaviour {

    public static int acornPortCount = 0;

	void OnTriggerEnter () {
        acornPortCount++;
	}
}
