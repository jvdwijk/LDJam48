using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private Health health;

    public override void Execute(UpgradeStat stat)
    {
        health.Max = health.Max + stat.statValue;
        health.Heal(stat.statValue);
    }
}
