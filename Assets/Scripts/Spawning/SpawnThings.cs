using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    public SpawningChance[] spawningChances;
    public float spawnDistance;

    public GameObject wormhead;
    
    private void Update()
    {
        foreach (SpawningChance chancy in spawningChances) //foreach prefab
        {
            float spawnRate = 0;
            for (int i = chancy.depthChance.Length - 1; i >= 0; i--) //check depth to determine chance
            {
                if (chancy.depthChance[i].depth <= -wormhead.transform.position.y)
                {
                    spawnRate = chancy.depthChance[i].rate;
                    break;
                }
            }
            if (spawnRate != 0 && Random.Range(0f,1f) < Time.deltaTime / 60 * spawnRate)
            {
                Spawn(chancy.prefab);
            }
        }
    }

    public void Spawn(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        //obj.transform.position = wormhead.transform.position + -wormhead.transform.up * spawnDistance + wormhead.transform.right * Random.Range(-spawnWidth, spawnWidth);
        
        float ang = -wormhead.transform.eulerAngles.z + Random.value * 180 + 90;
        Vector3 pos;
        pos.x = wormhead.transform.position.x + spawnDistance * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = wormhead.transform.position.y + spawnDistance * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = 0;
        obj.transform.position = pos;

        print(wormhead.transform.eulerAngles.z);
    }
}