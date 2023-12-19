using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    public bool isActive { get; set; }
    
    public void Active();

    public void Inactive();
    
    public void SetPosition(Vector2 position);
}
