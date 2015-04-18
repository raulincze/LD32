using UnityEngine;
using System.Collections;

public class SmartObjectBehaviour : MonoBehaviour 
{
    public Agent OwnerAgent { get; set; }

    public virtual void ApplyBehaviour(Action action)
    { 
        
    }
}
