using UnityEngine;
using System;

[Serializable]
public class SpawningChance
{
    public GameObject prefab;
    public bool upgradable;
    public DepthChance[] depthChance;
}
