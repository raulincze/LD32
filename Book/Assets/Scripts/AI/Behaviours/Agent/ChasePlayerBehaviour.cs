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
        newAction.distanceToTarget = 0.8f;
        newAction.speedMultiplier = 2f;
        Owner.ScheduleNewAction(newAction);
        KillPlayerAction newIdleAction = Owner.gameObject.AddComponent<KillPlayerAction>();
        Owner.ScheduleNewAction(newIdleAction);
    }
}
