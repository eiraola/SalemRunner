using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool 
{
    public void Pool(IPoolable poolable);
    public IPoolable Depool();
}
