using UnityEngine;
using System.Collections;

public class GuardBehavior : AgentBehaviour 
{

	public Transform target;

    public override void ApplyBehaviour()
    {
        if (Vector3.Distance(Owner.transform.position, target.position) < 0.4f)
            return;
        GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
        newAction.target = target;
        newAction.actionPriority = 20;
        newAction.distanceToTarget = 0.4f;
        Owner.ScheduleNewAction(newAction);
        RotateToAction rotateAction = Owner.gameObject.AddComponent<RotateToAction>();
        rotateAction.target = -target.rotation.eulerAngles;
        rotateAction.actionPriority = 10;
        Owner.ScheduleNewAction(rotateAction);
        GoToIdleAction newIdleAction = Owner.gameObject.AddComponent<GoToIdleAction>();
        newIdleAction.actionPriority = 0;
        Owner.ScheduleNewAction(newIdleAction);
    }
}
