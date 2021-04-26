using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;

    [SerializeField]
    private List<Upgrade> upgrades;

    private void Start()
    {
        if (instance == null) instance = this;
        else if (!instance.Equals(this)) Destroy(gameObject);

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
