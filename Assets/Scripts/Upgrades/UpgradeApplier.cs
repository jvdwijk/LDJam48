using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeApplier : MonoBehaviour
{
    [SerializeField]
    private List<UpgradesDictionary> upgradesDictionary = new List<UpgradesDictionary>();

    private UpgradeManager manager;

    private void Start()
    {
        manager = UpgradeManager.Instance;

        foreach (UpgradesDictionary dictionaryPart in upgradesDictionary)
        {
            UpgradeStat stat = manager.FindUpgrade(dictionaryPart.upgradeType).GetHighest(false);
            if (stat == null)
                continue;
            dictionaryPart.executor.Execute(stat);
        }
    }

}
