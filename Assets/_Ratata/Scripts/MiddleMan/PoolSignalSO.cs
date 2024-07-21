using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pool Signal", menuName = "ScriptableObjects/Pooling/Pool Signal", order = 2)]
[System.Serializable]
public class PoolSignalSO : ScriptableObject
{
    private IPool _pool;

    public IPoolable Depool()
    {
       return _pool.Depool();
    }

    public void Pool(IPoolable poolable)
    {
        _pool.Pool(poolable);
    }

    public void SetPool(IPool pool)
    {
        _pool = pool;
    }
}
