using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour, System.IComparable<Action>
{
    public Agent owner { get; private set; }
    public int Priority 
    { 
        get 
        {
            return actionPriority;
        } 
        private set
        {
            actionPriority = value;
        } 
    }

    public bool IsComplete { get; protected set; }

    public int actionPriority = 50;

    public int CompareTo(Action obj)
    {
        return obj.Priority - this.Priority;
    }

    void Awake()
    {
        owner = GetComponent<Agent>();
    }

    public virtual void Execute()
    { 
    
    }

    public virtual bool EvaluateCompletion()
    {
        return true;
    }
}
