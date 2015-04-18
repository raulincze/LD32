using UnityEngine;
using System.Collections;

public class GoToAction : Action 
{
    public Transform target;
    public float distanceToTarget = 0f;
    public float targetRefreshRate = 0.5f;

    public override void Execute()
    {
        StartCoroutine(FollowTarget());
        owner.SwitchState(new GoTo(owner.gameObject, target));
    }

    IEnumerator FollowTarget()
    {
        //Debug.Log("waaa");
        while (!EvaluateCompletion())
        {
           // Debug.Log("waaa");
            owner.navMeshAgent.SetDestination(target.position);
            yield return new WaitForSeconds(targetRefreshRate);
        }
    }

    public override bool EvaluateCompletion()
    {
        IsComplete = Vector3.Distance(owner.transform.position, target.position) <= distanceToTarget;
        return IsComplete;
    }
}
