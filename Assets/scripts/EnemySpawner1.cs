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

    public int totalEnemyCount = 5; // Określona ilość przeciwników do wygenerowania
    private int generatedEnemyCount = 0;

    public Transform playerTransform; // Referencja do transformacji gracza

    // Start is called before the first frame update
    void Start()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (generatedEnemyCount < totalEnemyCount)
        {
            _timeUntilSpawn -= Time.deltaTime;

            if (_timeUntilSpawn <= 0)
            {
                // Tworzymy przeciwnika
                GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

                // Sprawdzamy, czy przeciwnik ma skrypt EnemyWizardMovement
                EnemyWizardMovement wizardMovement = enemy.GetComponent<EnemyWizardMovement>();
                if (wizardMovement != null)
                {
                    wizardMovement.targetCharacter = playerTransform;
                }
                else
                {
                    // Jeżeli nie ma skryptu EnemyWizardMovement, sprawdzamy, czy ma skrypt EnemyWolfMovement
                    EnemyWolfMovement wolfMovement = enemy.GetComponent<EnemyWolfMovement>();
                    if (wolfMovement != null)
                    {
                        wolfMovement.targetCharacter = playerTransform;
                    }
                }

                SetTimeUntilSpawn();
                generatedEnemyCount++;
                Debug.Log(generatedEnemyCount);
            }
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}

