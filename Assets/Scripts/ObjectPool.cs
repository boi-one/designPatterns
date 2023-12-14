using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<IPoolObject> active = new List<IPoolObject>();
    public List<IPoolObject> inactive = new List<IPoolObject>();

    public void InstantiateObjects(int amount, IPoolObject obj)
    {
        for (int i = 0; i < amount; i++)
        {
            inactive.Add(obj);
            Instantiate(obj.body);
            obj.SetObjectInactive();
        }
    }
}
