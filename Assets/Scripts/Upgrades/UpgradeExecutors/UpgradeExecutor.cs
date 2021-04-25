using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeExecutor : MonoBehaviour
{
    public abstract void Execute(UpgradeStat stat);
}
