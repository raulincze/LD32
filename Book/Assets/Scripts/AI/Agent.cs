using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour 
{
    public State CurrentState { get { return stateMachine.CurrentState; } }
    public Action CurrentAction { get; private set; }
    public int ScheduledActionsCount { get { return actionQueue.Count(); } }
    public AgentBehaviour defaultBehaviour;
    public AgentBehaviour chasePlayerBehaviour;
    public Action currentAction;
    private StateMachine stateMachine;
    private GameObject thisGameObject;
    public NavMeshAgent navMeshAgent;

    public List<AcceptableBehaviour> possibleBehaviours;

    private PriorityQueue<Action> actionQueue;

    void Awake()
    {
        thisGameObject = gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine(new Idle(thisGameObject));
        actionQueue = new PriorityQueue<Action>();
      
    }

    void Start()
    {
        defaultBehaviour.ApplyBehaviour();
        //UseSmartObjectBehaviour[] smo = GetComponents<UseSmartObjectBehaviour>();
        //smo[1].ApplyBehaviour();
        //KillAgentBehavior ags = GetComponent<KillAgentBehavior>();
        //ags.ApplyBehaviour();
    }
	
	void Update() 
    {
        currentAction = CurrentAction;
        if (CurrentState is Dead)
            return;
        if (CurrentAction != null)
        {
            if (CurrentAction.EvaluateCompletion())
            {
                ExecuteNextAction();
            }
        }
        else
        {
            if (ScheduledActionsCount > 0)
            {
                ExecuteNextAction();
            }
            else
            {
                defaultBehaviour.ApplyBehaviour();
            }
        }
	}

    public void PlayAnimation(string anmiationName)
    { 
    
    }

    public void ScheduleNewAction(Action action)
    {
        actionQueue.Enqueue(action);
        if (CurrentAction != null)
        {
            if (action.Priority > CurrentAction.Priority)
            {
                ExecuteNextAction();
            }
        }
    }

    public void ExecuteNextAction()
    {
        if (CurrentAction != null)
        {
            GameObject.Destroy(CurrentAction);
        }
        if (actionQueue.Count() > 0)
        {
            CurrentAction = actionQueue.Dequeue();
            CurrentAction.Execute();
        }
    }

    public void SwitchState(State newState)
    {
        if (CurrentState is Dead)
            return;
        stateMachine.SwitchState(newState);
    }

    public void TransformInSight(Transform t)
    {
        if (t.CompareTag("Player") && chasePlayerBehaviour!=null)
        {
            chasePlayerBehaviour.ApplyBehaviour();
        }
    }

    internal void Die()
    {
        StopAllCoroutines();
        navMeshAgent.enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.Rotate(transform.forward, 5f);
    }

    public void UseBehaviour(AcceptableBehaviour toBeUsed)
    {
        toBeUsed.behaviour.ApplyBehaviour();
        if (toBeUsed.useOnce)
        {
            possibleBehaviours.Remove(toBeUsed);
        }
    }
}

[System.Serializable]
public class AcceptableBehaviour
{
    public AgentBehaviour behaviour;
    public string description;
    public bool useOnce = false;

    public override string ToString()
    {
        return description;
    }
}
