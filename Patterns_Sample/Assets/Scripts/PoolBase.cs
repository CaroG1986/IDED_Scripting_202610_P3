using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase<T> : MonoBehaviour
    where T : MonoBehaviour, IPoolable, IFactoryProduct
{
    [SerializeField]
    protected int poolSize = 10;

    protected List<T> pool = new List<T>();

    protected virtual void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            AddToPool();
        }
    }

    protected void AddToPool()
    {
        T obj = CreateInstance();

        obj.transform.SetParent(transform);

        obj.ResetObject(false);

        pool.Add(obj);
    }

    public virtual T Get()
    {
        if (pool.Count == 0)
        {
            AddToPool();
        }

        T obj = pool[0];

        pool.RemoveAt(0);

        obj.transform.SetParent(null);

        obj.ResetObject(true);

        return obj;
    }

    public virtual void Return(T obj)
    {
        obj.transform.SetParent(transform);

        obj.ResetObject(false);

        pool.Add(obj);
    }

    protected abstract T CreateInstance();
}