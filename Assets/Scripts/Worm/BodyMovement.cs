using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement: MonoBehaviour
{
    [SerializeField]
    private Transform follow;

    [SerializeField]
    private float followSpeed;

    public void SetUpFollow(Transform target)
    {
        follow = target;
    }

    void FixedUpdate()
    {
        transform.position = follow.position + (transform.position - follow.position).normalized * 2.5f;
        transform.localRotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, follow.position - transform.position) + 180);
    }
}