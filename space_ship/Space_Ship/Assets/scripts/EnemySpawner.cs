using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    float timer;

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
        Camera cam = Camera.main;

        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        float spawnX = width + 2f;
        float spawnY = Random.Range(-height, height);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
