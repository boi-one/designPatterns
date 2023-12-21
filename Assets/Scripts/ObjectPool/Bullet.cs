using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject
{
    public bool isActive { get; set; }
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
        if(rb) rb.velocity = new Vector2(0, 0);
        gameObject.SetActive(false);
    }
    
    public void SetDirection(Vector2 direction, float speed)
    {
        rb.velocity = direction.normalized * speed;
    }
    
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
