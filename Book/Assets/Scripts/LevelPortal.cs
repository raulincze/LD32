using UnityEngine;
using System.Collections;

public class LevelPortal : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
