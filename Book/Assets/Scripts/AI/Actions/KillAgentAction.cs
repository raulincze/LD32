using UnityEngine;
using System.Collections;

public class KillAgentAction : Action 
{
    public Transform target;
    private Agent targetAgent;

    public override void Execute()
    {
        IsComplete = false;
        targetAgent = target.GetComponent<Agent>();
        if (targetAgent == null)
        {
            IsComplete = true;
            return;
        }
        //PlayAnimation
        targetAgent.SwitchState(new Dead(targetAgent.gameObject));
    }

    public override bool EvaluateCompletion()
    {
        return targetAgent.CurrentState is Dead;
    }
}
