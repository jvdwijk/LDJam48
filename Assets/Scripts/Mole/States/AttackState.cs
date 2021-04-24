using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private TargetRotator rotator;

    [SerializeField]
    private float maxDistanceToPlayer;

    [SerializeField]
    private State chaseState;

    public override void EnterState()
    {
        base.EnterState();
        rotator.SetTarget(player);
        print("attack!!");
    }

    public override void LeaveState()
    {
        base.LeaveState();
        rotator.SetTarget(player);
    }

    public override void UpdateState(StateMachine machine)
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > maxDistanceToPlayer)
        {
            machine.SetState(chaseState);
        }
    }
}
