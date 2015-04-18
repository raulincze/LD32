using UnityEngine;
using System.Collections;

public class AgentBehaviour : MonoBehaviour 
{

    public Agent Owner { get; private set; }

    void Awake()
    {
        Owner = GetComponent<Agent>();
    }

    public virtual void ApplyBehaviour()
    { 
        
    }
}
