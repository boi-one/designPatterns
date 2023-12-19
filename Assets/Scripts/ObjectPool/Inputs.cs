using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public static ObjectPool<Bullet> bulletPool;
    [SerializeField] private float cooldown;
    private float tempTime;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        bulletPool = new ObjectPool<Bullet>(bulletPrefab.GetComponent<Bullet>());
        for (int i = 0; i < 30; i++)
        {
            Bullet bullet = bulletPool.NewObject();
            bullet.Setup(bulletPool);
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 screenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > tempTime)
        {
            tempTime = Time.time + cooldown;
            Bullet bullet = bulletPool.RequestObject(transform.position) as Bullet;
            if(bullet)
                bullet.SetDirection(Player.GetDirection(Player.playerPosition), bulletSpeed);
        }

        foreach (Bullet b in bulletPool.activePool.ToList())
        {
            if (b.transform.position.x > screenBorder.x || b.transform.position.x < -screenBorder.x ||
                b.transform.position.y > screenBorder.y || b.transform.position.y < -screenBorder.y )
                bulletPool.Inactive(b);
        }
    }
}
