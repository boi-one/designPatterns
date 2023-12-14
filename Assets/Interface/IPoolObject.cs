using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    public GameObject body { get; set; }
    public void SetObjectActive();
    public void SetObjectInactive();
}
