using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondOverlayYesScript : MonoBehaviour {
	public GameObject overlay2;

	// Use this for initialization
	void Start () {
	}

	public void ClickYesButton() {
		FlagHandler.SetItem("char2AtBeach", 1);
		FlagHandler.SetItem("char2Location", (int) SceneIDs.BEACH);
		FlagHandler.SetItem("carryingBasket", 1);
		FlagHandler.SetItem("basketState", 2);
		FlagHandler.ChangeScene("Potion Scenes/Potion - Hill");
	}
}
