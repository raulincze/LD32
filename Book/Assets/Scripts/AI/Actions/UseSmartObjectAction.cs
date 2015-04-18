using UnityEngine;
using System.Collections;

public class UseSmartObjectAction : Action 
{
    public SmartObjectBehaviour targetBehaviour;

    public override void Execute()
    {
        IsComplete = false;
        targetBehaviour.ApplyBehaviour(this);
        owner.SwitchState(new UseSmartObject(owner.gameObject, targetBehaviour.gameObject));
    }

    public override bool EvaluateCompletion()
    {
        return IsComplete;
    }
}
