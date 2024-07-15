using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnThings : MonoBehaviour
{
    [SerializeField]
    private SpawnPool spawnPool;
    [SerializeField]
    private SpawningChance[] spawningChances;
    
    public float spawnDistanceOffset;

    public float spawnChanceMultiplier = 1;

    public GameObject wormHead;

    [SerializeField, Range(0f, 360f), Tooltip("The field in front of the head in which the items spawn.")]
    private float spawnAngle = 180;

    [SerializeField, Range(0f, 360f), Tooltip("The offset by which to rotate the field in which items spawn")]
    private float spawnAngleOffset = 90;

    [SerializeField]
    private float despawnDistance = 1;

    [SerializeField]
    private bool showGizmos = false;

    private float cameraSizeCache, cameraAspectCache, viewportCornerDistanceCache;

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
        float spawnDistance = GetSpawnDistance();
        obj.transform.position = GetRandomSpawnLocation(spawnDistance);
        Despawn despawn = obj.GetComponent<Despawn>();
        despawn.despawnDistance = despawnDistance;
        despawn.wormHead = wormHead;
    }

    private Vector3 GetRandomSpawnLocation(float spawnDistance){
        var camera = Camera.main;
        float ang = -wormHead.transform.eulerAngles.z + Random.value * spawnAngle + spawnAngleOffset;
        return new Vector3(
            camera.transform.position.x + spawnDistance * Mathf.Sin(ang * Mathf.Deg2Rad),
            camera.transform.position.y + spawnDistance * Mathf.Cos(ang * Mathf.Deg2Rad),
            0
        );
    }

    private float GetSpawnDistance() {
        return GetDistanceToViewportCorner() + spawnDistanceOffset;
    }

    private float GetDistanceToViewportCorner() {
        var camera = Camera.main;
        if(cameraAspectCache == camera.aspect && cameraSizeCache == camera.orthographicSize)
            return viewportCornerDistanceCache;

        cameraAspectCache = camera.aspect;
        cameraSizeCache = camera.orthographicSize;
        var verticalSize = cameraSizeCache;
        var horizontalSize = cameraAspectCache * cameraSizeCache;
        viewportCornerDistanceCache = Mathf.Sqrt(verticalSize * verticalSize + horizontalSize * horizontalSize);
        return viewportCornerDistanceCache;
    }

    private void OnDrawGizmos() {
        if(!showGizmos)
            return;

        var camera = Camera.main;
        var spawnDistance = GetSpawnDistance();
        Gizmos.DrawWireSphere(camera.transform.position, spawnDistance);
        //Some Gizmo for showing the spawning field might be nice.
    }
}