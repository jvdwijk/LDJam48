using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceTrigger : MonoBehaviour
{
    public UnityEvent OnTrigger;
    
    private GameObject trigger;
    private float triggerRange;

    
    void Update()
    {
        if (Vector3.Distance(trigger.transform.position, transform.position) < triggerRange)//when within range trigger
        {
            OnTrigger.Invoke();
        }
    }

    public void SetTrigger(GameObject input)
    {
        trigger = input;
    }

    public void SetTriggerRange(float input)
    {
        triggerRange = input;
    }
}
