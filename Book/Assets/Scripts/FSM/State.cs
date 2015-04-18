using UnityEngine;
using System.Collections;

public abstract class State 
{
    public abstract void TransitionIn();
    public abstract void TransitionOut();
}
