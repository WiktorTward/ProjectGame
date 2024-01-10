using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;

    public int totalEnemyCount = 5; 
    private int generatedEnemyCount = 0;

    void Start()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        if (generatedEnemyCount < totalEnemyCount)
        {
            _timeUntilSpawn -= Time.deltaTime;

            if (_timeUntilSpawn <= 0)
            {
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
                generatedEnemyCount++;
            }
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}

