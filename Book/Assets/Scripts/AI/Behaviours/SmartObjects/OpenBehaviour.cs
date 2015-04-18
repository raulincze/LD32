using UnityEngine;
using System.Collections;

public class OpenBehaviour : SmartObjectBehaviour 
{
    Action action;

    public override void ApplyBehaviour(Action action)
    {
        GetComponent<Animation>().Play("Open");
        this.action = action;
        StartCoroutine(WaitForDoorToOpen(GetComponent<Animation>()["Open"].length));
    }

    IEnumerator WaitForDoorToOpen(float duration)
    {
        yield return new WaitForSeconds(duration);
        action.IsComplete = true;
    }
}
