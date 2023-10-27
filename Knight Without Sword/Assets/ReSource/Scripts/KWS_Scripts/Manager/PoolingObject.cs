using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : Singleton<PoolingObject>
{
    public void addPool(GameObject Pool, List<GameObject> pools, int Amount, Transform parent)
    {
        for (int i = 0; i < Amount; i++)
        {
            GameObject obj = Instantiate(Pool);
            obj.transform.SetParent(parent);
            obj.name = Pool.name;
            obj.SetActive(false);
            pools.Add(obj);
        }
    }
    public GameObject GetPoolingobj(List<GameObject> pools)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (!pools[i].activeInHierarchy)
            {
                return pools[i];
            }
        }
        return null;
    }
}
