using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField]
    public GameObject player;

    [SerializeField]
    private TargetRotator rotator;

    [SerializeField]
    private ObjectChaser chaser;

    [SerializeField]
    private float maxDistanceToPlayer;

    [SerializeField]
    private float minDistanceToPlayer;

    [SerializeField]
    private State chaseState;

    private Health playerHealth;

    private Coroutine attackRoutine;

    public float damage = 80;
    public float attackDelay = 2;

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();
    }

    public override void EnterState()
    {
        base.EnterState();
        rotator.SetTarget(player);
        chaser.ChaseObject(player);
        attackRoutine = StartCoroutine(Attackroutine());
    }

    public override void LeaveState()
    {
        base.LeaveState();
        rotator.SetTarget(player);
        chaser.ChaseObject(null);
        StopCoroutine(attackRoutine);
    }

    public override void UpdateState(StateMachine machine)
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > maxDistanceToPlayer)
        {
            machine.SetState(chaseState);
        }
        else if(distanceToPlayer < minDistanceToPlayer)
        {
            chaser.StopChasing();
        }
        else
        {
            chaser.ChaseObject(player);
        }

    }

    private IEnumerator Attackroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            playerHealth.Damage(damage);
        }
    }
}
