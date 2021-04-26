using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool : MonoBehaviour
{
    private Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    public GameObject PullObject(GameObject prefab)
    {
        GameObject obj;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new List<GameObject>());
        }
        if (pools[prefab].Count == 0)
        {
            pools[prefab].Add(Spawn(prefab));
        }
        obj = pools[prefab][0];
        pools[prefab].Remove(obj);
        obj.SetActive(true);
        return obj;
    }

    public void PushObject(GameObject obj, GameObject prefab)
    {
        obj.SetActive(false);
        pools[prefab].Add(obj);
    }

    public void Create(GameObject prefab, int amount)
    {
        GameObject obj;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new List<GameObject>());
        }
        for (int i = 0; i < amount; i++)
        {
            obj = Spawn(prefab);
            obj.SetActive(false);
            pools[prefab].Add(obj);
        }
    }

    private GameObject Spawn(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        Despawn despawn = obj.AddComponent<Despawn>();
        despawn.spawnPool = this;
        despawn.prefab = prefab;
        return obj;
    }
}
