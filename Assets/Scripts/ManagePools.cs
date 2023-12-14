using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePools : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Bullet bullet;
    public static ObjectPool bulletPool = new ObjectPool();
    // Start is called before the first frame update
    void Start()
    {
        bullet = new Bullet(bulletPrefab);
        bulletPool.InstantiateObjects(20, bullet);
    }
    
}
