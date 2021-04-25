using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceTrigger : MonoBehaviour
{
    public UnityEvent OnTrigger;
    
    private float triggerRange;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, triggerRange); //get all neirby colliders
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (hitCollider.TryGetComponent(out Health health)) //filter only Gameobjects within range and with the script health
            {
                OnTrigger.Invoke();
            }
        }
    }

    public void SetTriggerRange(float input)
    {
        triggerRange = input;
    }
}
