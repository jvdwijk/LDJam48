using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField]
    public GameObject player;

    [SerializeField]
    public LineOfSight lineOfsight;

    [SerializeField]
    private ChaseState chaseState;

    public override void UpdateState(StateMachine machine)
    {
        if (lineOfsight.IsObjectInView(player))
        {
            machine.SetState(chaseState);
        }
    }
}
