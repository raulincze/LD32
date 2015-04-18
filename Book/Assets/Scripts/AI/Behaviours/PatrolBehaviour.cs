using UnityEngine;
using System.Collections;

public class PatrolBehaviour : AgentBehaviour 
{
    public Transform[] wayPoints;

    public override void ApplyBehaviour()
    {
        StartCoroutine(RepeatAddActions());
    }

    IEnumerator RepeatAddActions()
    {
        while (true)
        {
            if (Owner.ScheduledActionsCount < wayPoints.Length)
            {
                AddActions();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void AddActions()
    {
        foreach (Transform t in wayPoints)
        { 
            GoToAction newAction = Owner.gameObject.AddComponent<GoToAction>();
            newAction.target = t;
            newAction.actionPriority = 0;
            Owner.ScheduleNewAction(newAction);
        }
    }
	
	
}
