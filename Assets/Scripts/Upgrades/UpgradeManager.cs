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
