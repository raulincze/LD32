using UnityEngine;
using System.Collections;

public class GoToIdleAction : Action
{
    public override void Execute()
    {
        owner.SwitchState(new Idle(owner.gameObject));
    }
}
