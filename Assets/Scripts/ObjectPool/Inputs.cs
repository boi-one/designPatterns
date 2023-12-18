using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public static ObjectPool<Bullet> bulletPool;
    void Start()
    {
        Debug.Log(bulletPrefab.GetComponent<Bullet>());
        bulletPool = new ObjectPool<Bullet>(bulletPrefab.GetComponent<Bullet>());
        for (int i = 0; i < 10; i++)
        {
            Bullet bullet = bulletPool.NewObject();
            bullet.Setup(bulletPool);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("input");
        }
    }
}
