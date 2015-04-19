using UnityEngine;
using System.Collections;

public class NarrativeNode : MonoBehaviour 
{
    public MessageBoxMessage[] messages;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i=0 ; i<messages.Length; i++)
            {
                if (i == 0)
                {
                    messages[i].Message = "\n\n" + messages[i].Message;
                }
                if (i == messages.Length - 1)
                {
                    messages[i].Message += "\n\n";
                }

                HUDManager.Instance.ShowMessage(messages[i]);
            }

            gameObject.SetActive(false);
        }
    }
}
