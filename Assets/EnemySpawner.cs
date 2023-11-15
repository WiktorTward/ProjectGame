using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Tablica prefabrykat�w przeciwnik�w
    public float spawnRate = 2.0f; // Cz�stotliwo�� spawnowania przeciwnik�w
    public float spawnRadius = 5.0f; // Promie� obszaru spawnu
    public int maxEnemies = 10; // Maksymalna liczba jednocze�nie istniej�cych przeciwnik�w

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
            // Losujemy pozycj� wewn�trz obszaru spawnu
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Wybieramy losowego przeciwnika z tablicy
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawnujemy przeciwnika na losowej pozycji
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Mo�esz doda� dodatkowe ustawienia dla przeciwnika (np. cel, trasy poruszania si� itp.) tutaj
        }
    }
}
