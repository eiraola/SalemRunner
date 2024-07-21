using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour, IPool
{
    [SerializeField] private GameObject _enemyGO;
    [SerializeField] private int _initialCapacity;
    [SerializeField] private PoolSignalSO _signalSO;
    private List<IPoolable> _enemyList = new List<IPoolable>();

    private void Start()
    {
        CreateInitialEnemies();
        _signalSO.SetPool(this);
    }

    private void CreateInitialEnemies() 
    {
        for (int i = 0; i < _initialCapacity; i++)
        {
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        GameObject gameObject = Instantiate(_enemyGO, transform.position, Quaternion.identity);
        if (gameObject.TryGetComponent<IPoolable>(out IPoolable poolable))
        {
            _enemyList.Add(poolable);
            gameObject.SetActive(false);
            gameObject.transform.SetParent(transform);
        }
    }

    public void Pool(IPoolable poolable)
    {
        poolable.Pool();
        poolable.GetGameObject().transform.parent = transform;
        _enemyList.Add(poolable);
    }

    public IPoolable Depool()
    {
        if (_enemyList.Count <= 0)
        {
            CreateNewEnemy();
        }

        IPoolable poolable = _enemyList[0];
        _enemyList.RemoveAt(0);
        poolable.GetGameObject().transform.parent = null;
        poolable.Depool();
        return poolable;
    }
}
