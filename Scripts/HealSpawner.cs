using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [Header("Healer Settings")]
    public GameObject healerPrefab;
    public Vector2 spawnRangeX = new Vector2(-10, 10);
    public Vector2 spawnRangeY = new Vector2(-5, 5);

    [Header("Spawning Settings")]
    public float timeBetweenSpawns = 5f;    // Time between spawn cycles
    public int healersPerSpawn = 1;         // How many healers to spawn each time
    public int maxHealers = 10;             // Max healers allowed in the scene

    private float timer;
    private List<GameObject> currentHealers = new List<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;

        // Clean up null references (in case healer was destroyed)
        currentHealers.RemoveAll(h => h == null);

        if (timer >= timeBetweenSpawns && currentHealers.Count < maxHealers)
        {
            SpawnHealers();
            timer = 0f;
        }
    }

    void SpawnHealers()
    {
        for (int i = 0; i < healersPerSpawn && currentHealers.Count < maxHealers; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(spawnRangeX.x, spawnRangeX.y),
                Random.Range(spawnRangeY.x, spawnRangeY.y),
                0
            );

            GameObject healer = Instantiate(healerPrefab, randomSpawnPosition, Quaternion.identity);
            currentHealers.Add(healer);
        }
    }
}
