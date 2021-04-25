using UnityEngine;
using System;

[Serializable]
public class DepthChance
{
    [Tooltip("this depth and below, unless overridden by the next 'Depth Chance'")]
    public float depth;
    [Tooltip("average spawns of this object per minute")]
    public float rate;
}