using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    // private int random;

    [Header("Spawn Timing")]
    public float startTimeBetweenSpawns = 3f;
    public float minTimeBetweenSpawns = 0.5f;         // Minimum allowed time between spawns
    public float difficultyIncreaseRate = 0.05f;      // How fast spawn time decreases
    private float timeBetweenSpawns;
    private float difficultyTimer = 0f;
    public float difficultyInterval = 10f;            // Every X seconds, increase difficulty

    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update()
    {
        // Decrease timer and spawn enemies
        timeBetweenSpawns -= Time.deltaTime;

        if (timeBetweenSpawns <= 0f)
        {
            SpawnEnemy();
            timeBetweenSpawns = startTimeBetweenSpawns;
        }

        // Every 'difficultyInterval' seconds, increase difficulty
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0f;

            // Reduce spawn time, clamped to minimum
            startTimeBetweenSpawns = Mathf.Max(minTimeBetweenSpawns, startTimeBetweenSpawns - difficultyIncreaseRate);
        }
    }

    void SpawnEnemy()
    {
        if (enemies.Length == 0 || spawnPoints.Length == 0) return;

        GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
