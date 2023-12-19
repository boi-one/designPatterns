using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
{
    public List<T> activePool = new List<T>();
    public List<T> inactivePool = new List<T>();
    private T instance; //is null

    public ObjectPool(T instance)
    {
        this.instance = instance;
    }

    public IPoolObject RequestObject(Vector2 position)
    {
        if (inactivePool.Count == 0) return null;
        else
        {
            T currentPoolObject = inactivePool[0];
            currentPoolObject.SetPosition(position);
            Active(currentPoolObject);
            return currentPoolObject;
        }
    }
    
    public T NewObject()
    {
        T instantiated = GameObject.Instantiate(instance);
        inactivePool.Add(instantiated);
        return instantiated;
    }

    public T Active(T obj)
    {
        obj.Active();
        obj.isActive = true;
        int index = inactivePool.IndexOf(obj);
        if (index != -1)
            inactivePool.RemoveAt(index);
        activePool.Add(obj);
        return obj;
    }

    public void Inactive(T obj)
    {
        int index = activePool.IndexOf(obj);
        if (index != -1)
            activePool.RemoveAt(index);
        obj.Inactive();
        obj.isActive = false;
        inactivePool.Add(obj);

    }
}
