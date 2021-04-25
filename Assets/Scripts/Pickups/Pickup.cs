using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    private List<string> wantedTag = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wantedTag.Contains(collision.gameObject.tag))
            OnEnter(collision);
    }

    protected abstract void OnEnter(Collider2D collision);
}
