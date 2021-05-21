using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour 
    where T : MonoBehaviour
{
    [SerializeField]
    private T prefab;

    [SerializeField]
    private int startAmount = 0;

    private readonly Queue<T> pool = new Queue<T>();

    public T ObjectPrefab => prefab;

    private void Awake()
    {
        for (int i = 0; i < startAmount; i++)
        {
            T obj = CreateNewObject();
            pool.Enqueue(obj);
        }
    }

    public T Get()
    {
        T nextObj = GetNextObject();
        ActivateObject(nextObj);
        return nextObj;
    }

    public void Return(T obj)
    {
        DeactivateObject(obj);
        pool.Enqueue(obj);
    }

    private T GetNextObject()
    {
        T obj;
        if (pool.Count < 1)
        {
            obj = CreateNewObject();
        } else {
            obj = pool.Dequeue();
        }
        return obj;
    }

    protected virtual T CreateNewObject()
    {
        return Instantiate(prefab);
    }

    protected virtual void ActivateObject(T obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.SetParent(null);
    }

    protected virtual void DeactivateObject(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
    }

}
