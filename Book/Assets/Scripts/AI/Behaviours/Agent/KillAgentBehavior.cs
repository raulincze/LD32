using UnityEngine;
using System.Collections;

public class KillAgentBehavior : AgentBehaviour 
{
    public Transform target;
    public override void ApplyBehaviour()
    {
        GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
        newAction.target = target;
        newAction.actionPriority = 50;
        newAction.distanceToTarget = 2f;
        Owner.ScheduleNewAction(newAction);
        KillAgentAction newKillAction = Owner.gameObject.AddComponent<KillAgentAction>();
        newKillAction.target = target;
        newKillAction.actionPriority = 50;
        Owner.ScheduleNewAction(newKillAction);
        GoToIdleAction newGTIAction = Owner.gameObject.AddComponent<GoToIdleAction>();
        newGTIAction.actionPriority = 50;
        Owner.ScheduleNewAction(newGTIAction);
    }
}
