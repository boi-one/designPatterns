using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{
    private GameObject body;
    private Rigidbody2D rb;
    private ObjectPool<Bullet> objectPool;
    
    public void Setup(ObjectPool<Bullet> pool)
    {
        rb = GetComponent<Rigidbody2D>();
        objectPool = pool;
    }
    
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Inactive()
    {
        rb.velocity = new Vector2(0, 0);
        gameObject.SetActive(false);
    }
}
