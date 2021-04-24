using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform follow;

    [SerializeField]
    private float followSpeed;

    private void SetUpFollow(Transform target)
    {
        follow = target;
    }

    void FixedUpdate()
    {
        var Position2D = Vector2.Lerp(this.transform.position, follow.transform.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(Position2D.x, Position2D.y, transform.position.z);
    }
}
