using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    public AttackState attack;
    public IdleState idle;
    public ChaseState chase;

    void Start()
    {
        GameObject player = (FindObjectOfType(typeof(WormMovement)) as WormMovement).gameObject;
        attack.player = player;
        idle.player = player;
        chase.player = player;
    }
}
