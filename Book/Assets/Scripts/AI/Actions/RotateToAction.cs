using UnityEngine;
using System.Collections;

public class RotateToAction : Action 
{

    public Vector3 target;
    public float time = 1f;

    public override void Execute()
    {
        owner.navMeshAgent.enabled = false;
        LeanTween.rotate(owner.gameObject, target, time).setEase(LeanTweenType.easeInCubic).setOnComplete(AnimationCompleteCallback);
    }

    public void AnimationCompleteCallback()
    {
        IsComplete = true;
        owner.navMeshAgent.enabled = true;
        owner.navMeshAgent.ResetPath();
    }

    public override bool EvaluateCompletion()
    {
        return IsComplete;
    }
}
