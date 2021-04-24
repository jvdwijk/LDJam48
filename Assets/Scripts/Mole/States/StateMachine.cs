using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    
    public void SetState(State newState)
    {
        currentState?.LeaveState();
        currentState = newState;
        currentState?.EnterState();
    }

    public void Update()
    {
        currentState?.UpdateState(this);
    }

}
