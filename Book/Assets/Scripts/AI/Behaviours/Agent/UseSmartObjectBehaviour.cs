using UnityEngine;
using System.Collections;

public class UseSmartObjectBehaviour : AgentBehaviour 
{
    public SmartObject smartObject;
    public SmartObjectBehaviour smartObjectBehaviour;

    public override void ApplyBehaviour()
    {
        GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
        newAction.target = smartObject.transform;
        newAction.actionPriority = 60;
        newAction.distanceToTarget = 1f;
        Owner.ScheduleNewAction(newAction);
        UseSmartObjectAction newSOAction = Owner.gameObject.AddComponent<UseSmartObjectAction>();
        newSOAction.targetBehaviour = smartObjectBehaviour;
        newSOAction.actionPriority = 50;
        Owner.ScheduleNewAction(newSOAction);
    }
}
