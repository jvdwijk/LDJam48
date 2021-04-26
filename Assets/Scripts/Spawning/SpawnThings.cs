using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    [SerializeField]
    private SpawnPool spawnPool;
    public SpawningChance[] spawningChances;
    public float spawnDistance;

    public float spawnChanceMultiplier = 1;

    public GameObject wormHead;

    private void Start()
    {
        
    }

    private void Update()
    {
        foreach (SpawningChance chancy in spawningChances) //foreach prefab
        {
            float spawnRate = 0;
            for (int i = chancy.depthChance.Length - 1; i >= 0; i--) //check depth to determine chance
            {
                if (chancy.depthChance[i].depth <= -wormHead.transform.position.y)
                {
                    spawnRate = chancy.depthChance[i].rate;
                    break;
                }
            }
            if (spawnRate != 0 && Random.Range(0f,1f) < Time.deltaTime / 60 * spawnRate * (chancy.upgradable ? spawnChanceMultiplier : 1))
            {
                Spawn(chancy.prefab);
            }
        }
    }

    public void Spawn(GameObject prefab) //spawns things in a half circle in front of the worm head at spawnDistance
    {
        GameObject obj = spawnPool.PullObject(prefab);
        
        float ang = -wormHead.transform.eulerAngles.z + Random.value * 180 + 90;
        Vector3 pos;
        pos.x = wormHead.transform.position.x + spawnDistance * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = wormHead.transform.position.y + spawnDistance * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = 0;
        obj.transform.position = pos;

        Despawn despawn = obj.GetComponent<Despawn>();
        despawn.despawnDistance = spawnDistance + 1;
        despawn.wormHead = wormHead;
    }
}