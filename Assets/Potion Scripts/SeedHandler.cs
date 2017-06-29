using UnityEngine;
using System.Collections;

public class SeedHandler : MonoBehaviour {

    public bool isSeed = true;
    private static bool isHoldingSeed = false;
    public GameObject self;
    /*public VRStandardAssets.Examples.InteractiveItemSeed*/ bool clickHandler;
    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (clickHandler/*.hasObjectBeenClicked*/ == true)
        {
            if (isSeed == true && isHoldingSeed == false)
            {
                isHoldingSeed = true;
                self.SetActive(false);
            }
            if (isSeed == false && isHoldingSeed == true)
            {
                isHoldingSeed = false;
                self.SetActive(true);
            }
            clickHandler/*.hasObjectBeenClicked*/ = false;
        }
        print(isHoldingSeed);
    }


    public static bool getIsHoldingSeed()
    {
        return isHoldingSeed;
    }
}
