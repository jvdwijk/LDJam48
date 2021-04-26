using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float triggerRange, triggerDelay, explosionRange, explosionDamage;
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Sprite triggeredMine;
    [SerializeField]
    private SpriteRenderer mineImage;

    void Start()
    {
        DistanceTrigger dt = GetComponent<DistanceTrigger>();
        dt.SetTriggerRange(triggerRange);
        dt.OnTrigger.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        mineImage.sprite = triggeredMine;
        timer.StartTimer(triggerDelay);
    }

    public void Explode()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange); //get all neirby colliders
        foreach (var hitCollider in hitColliders)
        {
            print("kahga");
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < explosionRange && hitCollider.TryGetComponent(out Health health)) //filter only Gameobjects within range and with the script health
            {
                health.Damage(explosionDamage * (1 - distance / explosionRange)); //less damage the further you are from the mine
            }
        }
        Destroy(gameObject);
    }
}
