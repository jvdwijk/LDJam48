using UnityEngine;
using System;

[Serializable]
public class SpawningChance
{
    public GameObject prefab;
    public DepthChance[] depthChance;
    public bool upgradable;
}
