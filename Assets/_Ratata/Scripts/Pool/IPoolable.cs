using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{
    public void Pool();
    public void Depool();
    public GameObject GetGameObject();
}
