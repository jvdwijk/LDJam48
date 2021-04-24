using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private GameObject trigger;
    [SerializeField]
    private float triggerRange, triggerDelay, explosionRange, explosionDamage;
    [SerializeField]
    private Timer timer;

    void Start()
    {
        DistanceTrigger dt = GetComponent<DistanceTrigger>();
        dt.SetTrigger(trigger);
        dt.SetTriggerRange(triggerRange);
        dt.OnTrigger.AddListener(StartTimer);
    }
    
    void Update()
    {
        
    }

    private void StartTimer()
    {
        timer.StartTimer(triggerDelay);
    }

    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRange);
        foreach (var hitCollider in hitColliders)
        {
            if(Vector3.Distance(hitCollider.transform.position, transform.position) < explosionRange && hitCollider.TryGetComponent(out Health health))
            {
                health.Damage(explosionDamage);
            }
        }
    }
}
