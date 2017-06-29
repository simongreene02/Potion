using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToSceneOnTrigger : MonoBehaviour
{

    public Object sceneToLoad;

    IEnumerator OnTriggerEnter(Collider other) //Senses when an controller touches the designated trigger
    {
        if (other.tag == "Special")
            Debug.Log("Object Entered the Face Trigger");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(sceneToLoad.name); //This will load the scene that is named "Cabin" change the scene name in the script
    }

} 