using UnityEngine;
using System.Collections;

public class ChasePlayerBehaviour : AgentBehaviour 
{

	private Transform target;

    public override void ApplyBehaviour()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
        newAction.target = target;
        newAction.actionPriority = 100;
        newAction.distanceToTarget = 0.1f;
        Owner.ScheduleNewAction(newAction);
        GoToIdleAction newIdleAction = Owner.gameObject.AddComponent<GoToIdleAction>();
        Owner.ScheduleNewAction(newIdleAction);
    }
}
