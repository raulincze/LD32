using UnityEngine;
using System.Collections;

public class AdmireBehaviour : SmartObjectBehaviour
{
    public float admireFor = 3f;
    public override void ApplyBehaviour(Action action)
    {
        StartCoroutine(WaitAndAdmire(action));
    }

    IEnumerator WaitAndAdmire(Action action)
    {
        yield return new WaitForSeconds(admireFor);
        action.IsComplete = true;
    }
}
