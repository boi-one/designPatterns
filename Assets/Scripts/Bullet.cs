using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : IPoolObject
{
    public Transform playerTransform;
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject body { get; set; }
    public float damage;

    public Bullet(GameObject body)
    {
        this.body = body;
        rb = body.GetComponent<Rigidbody2D>();
    }
    
    Vector2 GetDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return (new Vector2(mousePos.x, mousePos.y) - Player.playerPosition).normalized;
    }

    public void SetObjectInactive()
    {
        rb.velocity = new Vector2(0, 0);
        body.SetActive(false);

    }

    public void SetObjectActive()
    {
        body.SetActive(true);
        body.transform.position = Player.playerPosition;
        body.GetComponent<Rigidbody2D>().velocity = GetDirection() * movementSpeed;
    }
}
