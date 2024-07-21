using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    [SerializeField] private PoolSignalSO _poolSignalSo;
    [SerializeField] private ScenarioDataSO _scenarioDataSo;
    private IPoolable enemy;

    private void Start()
    {
        enemy = GetComponent<IPoolable>();
    }

    private void Update()
    {
        DespawnEnemy();
    }

    public void DespawnEnemy()
    {

        if (_scenarioDataSo.EndPosition.x > transform.position.x + 3.0f)
        {
             _poolSignalSo.Pool(enemy);
        }
    }

}
