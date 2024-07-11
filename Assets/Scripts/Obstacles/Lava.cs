using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField]
    private float damageRadius = 15, damageRate = 3, impactDamage = 5000;
    
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius); //get all neirby colliders
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < damageRadius && hitCollider.TryGetComponent(out Health health)) //filter only Gameobjects within range and with the script health
            {
                DamageFeedback.Instance.FireDamage();
                health.Damage(damageRate * Time.deltaTime * (1 - distance / damageRadius)); //less damage over time the further you are from the mine
            }
            else if(hitCollider.TryGetComponent(out Health bealth))
            {
                DamageFeedback.Instance.FireDamage(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Health health))
        {
            health.Damage(impactDamage);//if colliding entity has health then die
        }
    }
}
