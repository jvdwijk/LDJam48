using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float despawnDistance = 0;
    public GameObject wormHead;
    public GameObject prefab; //used as key for the spawnpool
    public SpawnPool spawnPool;
    
    void Update()
    {
        if (despawnDistance != 0 && (wormHead.transform.position - transform.position).magnitude > despawnDistance)
        {
            spawnPool.PushObject(gameObject, prefab);
        }
    }
}
