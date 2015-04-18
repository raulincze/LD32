using UnityEngine;
using System.Collections;

public class Idle : State 
{
    private GameObject agent;
    public Idle(GameObject agent)
    {
        this.agent = agent;
    }

    public override void TransitionIn()
    {
       
    }

    public override void TransitionOut()
    {
       
    }
}
