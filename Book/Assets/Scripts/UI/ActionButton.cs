using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour 
{
    public AcceptableBehaviour behav;
    public Agent agent;
    public Text label;

    public void DisplayText()
    {
        label.text = behav.ToString();
    }

    public void Click()
    {
        agent.UseBehaviour(behav);
        HUDManager.Instance.HideActionMenu();
    }
}
