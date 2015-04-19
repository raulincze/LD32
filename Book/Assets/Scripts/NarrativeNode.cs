using UnityEngine;
using System.Collections;

public class NarrativeNode : MonoBehaviour 
{
    public MessageBoxMessage[] messages;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (MessageBoxMessage m in messages)
            {
                HUDManager.Instance.ShowMessage(m);
            }
        }
    }
}
