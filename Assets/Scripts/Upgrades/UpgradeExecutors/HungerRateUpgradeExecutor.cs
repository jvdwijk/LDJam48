using UnityEngine;

public class HungerRateUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private Hunger hunger;

    public override void Execute(UpgradeStat stat)
    {
        hunger.HungerRate = stat.statValue;
    }
}
