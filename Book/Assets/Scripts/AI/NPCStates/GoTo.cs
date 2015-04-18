using UnityEngine;
using System.Collections;

public class GoTo : State
{
    private GameObject agent;
    private Transform target;
    public GoTo(GameObject agent, Transform target)
    {
        this.agent = agent;
        this.target = target;
    }

    public override void TransitionIn()
    {

    }

    public override void TransitionOut()
    {

    }
}
