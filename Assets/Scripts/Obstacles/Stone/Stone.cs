using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    private float hungerMult = 2, speedMult = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hunger hunger))
        {
            hunger.multHunger(hungerMult);
        }
        if (collision.TryGetComponent(out WormMovement wormMovement))
        {
            wormMovement.multSpeed(speedMult);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hunger hunger))
        {
            hunger.multHunger(1 / hungerMult);
        }
        if (collision.TryGetComponent(out WormMovement wormMovement))
        {
            wormMovement.multSpeed(1 / speedMult);
        }
    }
}
