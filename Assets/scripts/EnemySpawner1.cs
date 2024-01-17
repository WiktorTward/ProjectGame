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

    public int totalEnemyCount = 5; // Okre�lona ilo�� przeciwnik�w do wygenerowania
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

                // Przypisujemy transformacj� gracza do przeciwnika
                enemy.GetComponent<EnemyWizardMovement>().targetCharacter = playerTransform;



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

