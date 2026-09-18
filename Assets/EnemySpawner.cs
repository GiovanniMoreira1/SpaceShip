using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 2f;

    public float spawnX = 10f;
    public float minY = -4f;
    public float maxY = 4f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(
            spawnX,
            randomY,
            0
        );

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}