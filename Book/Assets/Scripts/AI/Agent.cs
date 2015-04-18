using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour 
{
    public State CurrentState { get { return stateMachine.CurrentState; } }
    public Action CurrentAction { get; private set; }
    public int ScheduledActionsCount { get { return actionQueue.Count(); } }
    public AgentBehaviour defaultBehaviour;

    private StateMachine stateMachine;
    private GameObject thisGameObject;
    public NavMeshAgent navMeshAgent;

    private PriorityQueue<Action> actionQueue;

    void Awake()
    {
        thisGameObject = gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine(new Idle(thisGameObject));
        actionQueue = new PriorityQueue<Action>();
        defaultBehaviour.ApplyBehaviour();
    }
	
	void Update() 
    {
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
        }
	}

    public void PlayAnimation(string anmiationName)
    { 
    
    }

    public void ScheduleNewAction(Action action)
    {
        actionQueue.Enqueue(action);
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
        stateMachine.SwitchState(newState);
    }
}
