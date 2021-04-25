using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private ObjectChaser chaser;

    [SerializeField]
    private TargetRotator rotator;

    [SerializeField]
    private float maxDistanceToPlayer = 50;

    [SerializeField]
    private float minDistanceToPlayer = 1;

    [SerializeField]
    private State idleState, attackState;

    public override void EnterState()
    {
        chaser.ChaseObject(player);
        rotator.SetTarget(player);
    }

    public override void LeaveState()
    {
        chaser.StopChasing();
        rotator.SetTarget(null);
    }

    public override void UpdateState(StateMachine machine)
    {

        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer > maxDistanceToPlayer)
        {
            machine.SetState(idleState);
        }
        else if (distanceToPlayer < minDistanceToPlayer)
        {
            machine.SetState(attackState);
        }
    }
}
