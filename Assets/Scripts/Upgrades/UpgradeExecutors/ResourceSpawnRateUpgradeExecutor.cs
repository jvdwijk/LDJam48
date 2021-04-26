using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawnRateUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private SpawnThings spawnThings;

    public override void Execute(UpgradeStat stat)
    {
        spawnThings.spawnChanceMultiplier = spawnThings.spawnChanceMultiplier + stat.statValue;
    }
}
