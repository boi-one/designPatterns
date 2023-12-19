using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public static ObjectPool<Bullet> bulletPool;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Bullet bullet = bulletPool.RequestObject(transform.position) as Bullet;
            if(bullet)
                bullet.SetDirection(Player.GetDirection(Player.playerPosition), 5);
        }

        foreach (Bullet b in bulletPool.activePool.ToList())
        {
            if (b.transform.position.x > Player.screenBorder.x || b.transform.position.x < -Player.screenBorder.x ||
                b.transform.position.y > Player.screenBorder.y || b.transform.position.y < -Player.screenBorder.y)
                bulletPool.Inactive(b);
        }
    }
}
