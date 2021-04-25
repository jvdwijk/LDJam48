using UnityEngine;

public class ValuablePickup : Pickup
{
    [SerializeField]
    private ValuableStats stats;

    protected override void OnEnter(Collider2D collision)
    {
        ValuableKeeper keeper = FindObjectOfType<ValuableKeeper>();
        keeper.AddValuable(stats);
        Destroy(gameObject);
    }
}
