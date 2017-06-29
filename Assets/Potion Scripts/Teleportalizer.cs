using UnityEngine;
using System.Collections;

public class Teleportalizer : MonoBehaviour
{
    public GameObject TeleportTo;
    public Material NewSkybox;
    public GameObject player;

    // May replace "player" with "other" to teleport gameobjects other than player
    void OnTriggerEnter(Collider other)
    {
        Vector3 displacement = player.transform.position - transform.position;

        player.transform.position = TeleportTo.transform.position;
        player.transform.position += displacement;

        RenderSettings.skybox = NewSkybox;

        //Destroy(pathObject);

        //Instantiate(pathObject, TeleportTo.transform.position, transform.rotation);
    }
}
