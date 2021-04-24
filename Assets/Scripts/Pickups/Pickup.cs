using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    private string wantedTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == wantedTag)
            OnEnter(collision);
    }

    protected abstract void OnEnter(Collider2D collision);
}
