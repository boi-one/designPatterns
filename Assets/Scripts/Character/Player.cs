using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character, ICommand
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public float jumpForce;
    private Vector2 velocity;
    private Vector2 mousePosition;
    [SerializeField] private float movementSpeed;
    
    public GameObject bulletPrefab;
    public static ObjectPool<Bullet> bulletPool;
    [SerializeField] private float cooldown;
    private float tempTime;
    [SerializeField] private float bulletSpeed;

    private Vector2 direction;
    public static Vector3 screenBorder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        bulletPool = new ObjectPool<Bullet>(bulletPrefab.GetComponent<Bullet>());
        for (int i = 0; i < 20; i++)
        {
            Bullet bullet = bulletPool.NewObject();
            bullet.Setup(bulletPool);
        }
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        screenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        
        foreach (Bullet b in bulletPool.activePool.ToList())
        {
            if (b.transform.position.x > screenBorder.x || b.transform.position.x < transform.position.x - 10 /*-screenBorder.x*/ ||
                b.transform.position.y > screenBorder.y || b.transform.position.y < transform.position.y - 10 /*-screenBorder.y*/ )
                bulletPool.Inactive(b);
        }
    }

    public void Execute()
    {
        
    }
    
    public override void Move()
    {
        rb.velocity = new Vector2(velocity.x * movementSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (!isGrounded) return;
        isGrounded = false;
        rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
    }

    public void Shoot()
    {
        if (Time.time > tempTime)
        {
            tempTime = Time.time + cooldown;
            Bullet bullet = bulletPool.RequestObject(transform.position) as Bullet;
            if(bullet)
                bullet.SetDirection(direction, bulletSpeed);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
}
