using UnityEngine;
using System.Collections;

public class PersistGameObject : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}