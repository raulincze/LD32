using UnityEngine;
using System.Collections;

public class Dead : State 
{
    GameObject agent;

    public Dead(GameObject agent)
    {
        this.agent = agent;
    }

    public override void TransitionIn()
    {
        agent.GetComponent<Agent>().Die();
    }
    public override void TransitionOut()
    { 
    
    }
}
