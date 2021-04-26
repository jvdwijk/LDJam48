using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Upgrade
{
    [SerializeField]
    private string title = "Good Upgrade";
    [SerializeField]
    private UpgradeType type;
    [SerializeField]
    private List<UpgradeStat> upgradeValues;

    public string GetTitle
    {
        get { return title; }
    }

    public UpgradeType GetUpgradeType
    {
        get { return type; }
    }

    public List<UpgradeStat> UpgradeValues => upgradeValues;

    /// <summary>
    /// Gets the next locked upgrade or the highest unlocked upgrade.
    /// </summary>
    /// <param name="isLocked">Do you want the next locked (true) or the highest unlocked (false)</param>
    /// <returns>Returns the highest possible upgrade</returns>
    public UpgradeStat GetHighest(bool isLocked = false) {
        UpgradeStat previousStat = null;

        foreach (UpgradeStat stat in upgradeValues)
        {
            if (!stat.unlocked)
                return isLocked ? stat : previousStat;
            previousStat = stat;
        }
        return isLocked ? null : previousStat;
    }

    public int GetUnlockedUpgradeAmount()
    {
        int amountUnlocked = 0;
        foreach (UpgradeStat stat in upgradeValues)
        {
            if (stat.unlocked) amountUnlocked++;
        }

        return amountUnlocked;
    }

    public int GetTotalUpgrades()
    {
        return upgradeValues.Count;
    }
}
