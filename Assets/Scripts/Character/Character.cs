using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float health;
    public float speed;

    public abstract void Move();

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
    }
}
