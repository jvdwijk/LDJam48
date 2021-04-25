using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private List<Upgrade> upgrades;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
}
