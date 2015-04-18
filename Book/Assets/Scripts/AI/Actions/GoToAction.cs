using UnityEngine;
using System.Collections;

public class GoToAction : Action 
{
    public Transform target;
    public float distanceToTarget = 0f;
    public float targetRefreshRate = 0.5f;
    public float speedMultiplier = 1.0f;
    public override void Execute()
    {
        owner.navMeshAgent.acceleration *= speedMultiplier;
        owner.navMeshAgent.speed *= speedMultiplier;
        StartCoroutine(FollowTarget());
        owner.SwitchState(new GoTo(owner.gameObject, target));
    }

    IEnumerator FollowTarget()
    {
        while (!EvaluateCompletion() && owner.navMeshAgent.enabled)
        {
            owner.navMeshAgent.SetDestination(target.position);
            yield return new WaitForSeconds(targetRefreshRate);
        }
    }

    public override bool EvaluateCompletion()
    {
        if (!IsComplete)
        {
            IsComplete = Vector3.Distance(owner.transform.position, target.position) <= distanceToTarget;
            if (IsComplete)
            {
                owner.navMeshAgent.acceleration /= speedMultiplier;
                owner.navMeshAgent.speed /= speedMultiplier;
            }
        }
        return IsComplete;
    }
}
