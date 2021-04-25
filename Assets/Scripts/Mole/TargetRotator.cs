using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private GameObject target;

    private float targetAngle;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
            return;

        var targetAngle = Vector2.SignedAngle(Vector3.up, target.transform.position - transform.position);
      
        var rotation = transform.rotation.eulerAngles;
        rotation.z = targetAngle;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), rotationSpeed*Time.deltaTime);
    }
}
