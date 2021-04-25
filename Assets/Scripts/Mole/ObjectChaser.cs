using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChaser : MonoBehaviour
{

    private GameObject target;

    public float speed = 10;

    public void ChaseObject(GameObject obj)
    {
        target = obj;
    }

    public void StopChasing()
    {
        target = null;
    }

    private void Update()
    {
        if (target == null)
            return;
        
        var dirToTarget = target.transform.position - transform.position;
        dirToTarget.Normalize();

        transform.position += dirToTarget * speed * Time.deltaTime;
    }
}
