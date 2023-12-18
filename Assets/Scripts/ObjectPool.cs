using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolObject
{
    public List<T> active = new List<T>();
    public List<T> inactive = new List<T>();

    public void InstantiateObjects(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            inactive.Add(obj);
            Instantiate(obj.body);
            obj.SetObjectInactive();
        }
    }
    
}
