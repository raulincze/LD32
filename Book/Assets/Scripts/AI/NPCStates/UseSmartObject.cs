using UnityEngine;
using System.Collections;

public class UseSmartObject : State
{
    private GameObject agent;
    private GameObject smartObject;

    public UseSmartObject(GameObject agent, GameObject smartObject)
    {
        this.agent = agent;
        this.smartObject = smartObject;
    }

    public override void TransitionIn()
    {

    }

    public override void TransitionOut()
    {

    }
}
