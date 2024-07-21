using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PoolSignalSO _poolSignalSo;
    [SerializeField] private ScenarioDataSO _scenarioDataSo;
    private bool _hasSpawned = false;

    private void OnEnable()
    {
        _hasSpawned = false;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (_hasSpawned)
        {
            return;
        }

        if (_scenarioDataSo.StartPosition.x > transform.position.x)
        {
            Ghost enemy = (Ghost) _poolSignalSo.Depool();
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.identity;
            enemy.gameObject.SetActive(true);
            _hasSpawned = true;
        }
    }

}
