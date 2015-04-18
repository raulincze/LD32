using UnityEngine;
using System.Collections;

public class GuardBehavior : AgentBehaviour 
{

	public Transform target;

    public override void ApplyBehaviour()
    {
        GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
        newAction.target = target;
        newAction.actionPriority = 0;
        newAction.distanceToTarget = 0.1f;
        Owner.ScheduleNewAction(newAction);
        GoToIdleAction newIdleAction = Owner.gameObject.AddComponent<GoToIdleAction>();
        Owner.ScheduleNewAction(newIdleAction);
    }
}
