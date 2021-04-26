using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;

    public static UpgradeManager Instance
    {
        get { return instance; }
    }

    [SerializeField]
    private List<Upgrade> upgrades;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    private void LoadData()
    {
        foreach (UpgradeType upgradeName in UpgradeType.GetValues(typeof(UpgradeType)))
        {
            int upgradedLevel = PlayerPrefs.GetInt("UpgradeLevel" + upgradeName);
            if (upgradedLevel == 0)
                continue;

            UpgradeType type = (UpgradeType) PlayerPrefs.GetInt("UpgradeType" + upgradeName);
            Upgrade upgrade = FindUpgrade(type);

            for (int i = 0; i < upgradedLevel; i++)
            {
                upgrade.GetHighest(true).unlocked = true;
            }
        }
    }

    public List<Upgrade> GetUpgrades
    {
        get { return upgrades; }
    }

    public Upgrade FindUpgrade(UpgradeType type)
    {
        foreach (Upgrade upgrade in upgrades)
        {
            if (upgrade.GetUpgradeType.Equals(type))
                return upgrade;
        }
        return null;
    }

    /// <summary>
    /// Calculate the percentage of upgrades unlocked.
    /// </summary>
    /// <returns>Returns a value between 0 and 1.</returns>
    public float GetPercentageUnlocked()
    {
        float totalUpgrades = 0;
        float unlockedUpgrades = 0;

        foreach (Upgrade upgrade in upgrades)
        {
            totalUpgrades += upgrade.GetTotalUpgrades();
            unlockedUpgrades += upgrade.GetUnlockedUpgradeAmount();
        }

        return unlockedUpgrades / totalUpgrades;
    }
}
