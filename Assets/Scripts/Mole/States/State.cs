using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void EnterState() { }

    public abstract void UpdateState(StateMachine machine);

    public virtual void LeaveState() { }
}
