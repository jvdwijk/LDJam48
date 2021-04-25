using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float damageRadius, damageRate;
    
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius); //get all neirby colliders
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < damageRadius && hitCollider.TryGetComponent(out Health health)) //filter only Gameobjects within range and with the script health
            {
                health.Damage(damageRate * Time.deltaTime * (1 - distance / damageRadius)); //less damage over time the further you are from the mine
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent(out Health health))
        {
            health.Damage(Mathf.Infinity);//if colliding entity has health then die
        }
    }
}
