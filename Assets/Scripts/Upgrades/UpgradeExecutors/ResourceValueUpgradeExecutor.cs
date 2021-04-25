using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceValueUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private ValuableKeeper keeper;

    public override void Execute(UpgradeStat stat)
    {
        keeper.ValueMult = stat.statValue;
    }
}
