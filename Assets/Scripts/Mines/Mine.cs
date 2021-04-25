using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float triggerRange, triggerDelay, explosionRange, explosionDamage;
    [SerializeField]
    private Timer timer;


    void Start()
    {
        DistanceTrigger dt = GetComponent<DistanceTrigger>();
        dt.SetTriggerRange(triggerRange);
        dt.OnTrigger.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        timer.StartTimer(triggerDelay);
    }

    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRange); //get all neirby colliders
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < explosionRange && hitCollider.TryGetComponent(out Health health)) //filter only Gameobjects within range and with the script health
            {
                health.Damage(explosionDamage * (1 - distance / explosionRange)); //less damage the further you are from the mine
            }
        }
    }
}
