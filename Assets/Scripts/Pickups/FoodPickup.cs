using UnityEngine;

public class FoodPickup : Pickup
{
    [SerializeField]
    private float healAmount = 10;

    protected override void OnEnter(Collider2D collision)
    {
        collision.GetComponentInParent<Health>().Heal(healAmount);
        Destroy(gameObject);
    }
}
