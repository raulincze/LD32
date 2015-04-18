using UnityEngine;
using System.Collections;

public class StateMachine 
{
    public State CurrentState { get; protected set; }

    public StateMachine(State initialState)
    {
        CurrentState = initialState;
        CurrentState.TransitionIn();
    }

    public virtual void SwitchState(State newState)
    {
        CurrentState.TransitionIn();
        CurrentState = newState;
        CurrentState.TransitionIn();
    }

}
