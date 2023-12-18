using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
{
    private List<T> active = new List<T>();
    private List<T> inactive = new List<T>();
    private T instance; //is null

    public ObjectPool(T instance)
    {
        this.instance = instance;
    }

    public T NewObject()
    {
        T instantiated = GameObject.Instantiate(instance);
        inactive.Add(instantiated);
        return instantiated;
    }

    public void Active(IPoolObject obj)
    {
        
    }

    public void Inactive(IPoolObject obj)
    {
        obj.Active();
        
    }
}
