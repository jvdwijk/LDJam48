using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
            return;

        var angle = Vector2.SignedAngle(Vector3.up, target.transform.position - transform.position);
        var rotation = transform.rotation.eulerAngles;
        rotation.z = angle;

        transform.eulerAngles = rotation;
    }
}
