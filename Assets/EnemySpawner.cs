using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Tablica prefabrykatów przeciwników
    public float spawnRate = 2.0f; // Czêstotliwoœæ spawnowania przeciwników
    public float spawnRadius = 5.0f; // Promieñ obszaru spawnu
    public int maxEnemies = 10; // Maksymalna liczba jednoczeœnie istniej¹cych przeciwników

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
            // Losujemy pozycjê wewn¹trz obszaru spawnu
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Wybieramy losowego przeciwnika z tablicy
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawnujemy przeciwnika na losowej pozycji
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Mo¿esz dodaæ dodatkowe ustawienia dla przeciwnika (np. cel, trasy poruszania siê itp.) tutaj
        }
    }
}
