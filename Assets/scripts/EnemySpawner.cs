using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Tablica prefabrykatów przeciwników
    public float spawnRate = 2.0f; // Częstotliwość spawnowania przeciwników
    public float spawnRadius = 5.0f; // Promień obszaru spawnu
    public int maxEnemies = 10; // Maksymalna liczba jednocześnie istniejących przeciwników

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            // Losujemy pozycję wewnątrz obszaru spawnu
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Wybieramy losowego przeciwnika z tablicy
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawnujemy przeciwnika na losowej pozycji
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Możesz dodać dodatkowe ustawienia dla przeciwnika (np. cel, trasy poruszania się itp.) tutaj
        }
    }
}
