using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public int numEnemiesBeforeFinished = 25;
    public int initialSpawnCount = 5;
    public int spawnGroupSize = 5;
    int currSpawnCount = 0;

    public bool isEmpty = false;

    public float spawnRange = 25f;
    public float spawnTime = 5f;
    float currSpawnTime = 0f;
    bool isPlayerInRange = false;

    public float spawnRadius = 7.5f;

    public GameObject[] enemyPrefabs;

    void Start() {
        currSpawnTime = spawnTime;
        SpawnEnemies(initialSpawnCount);
        InvokeRepeating("CheckPlayerInRange", 0, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        if (!isPlayerInRange) return;
        if (currSpawnCount < numEnemiesBeforeFinished) {
            currSpawnTime -= Time.deltaTime;
            if (currSpawnTime <= 0f) {
                SpawnEnemies(spawnGroupSize);
                currSpawnTime = spawnTime;
            }
        } else {
            isEmpty = true;
        }
    }

    void SpawnEnemies(int count) {
        Debug.Log("Spawning " + count + " enemies");
        for (int i = 0; i < count && currSpawnCount <= numEnemiesBeforeFinished; i++) {
            Vector3 spawnPos = transform.position + Random.onUnitSphere * spawnRadius;
            spawnPos.y = 0;
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity);
            enemy.transform.parent = transform;
            currSpawnCount++;
        }
    }

    bool IsPlayerInRange() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, spawnRange,  1 << LayerMask.NameToLayer("Player"));
        return hitColliders.Length > 0;
    }

    void CheckPlayerInRange() {
        isPlayerInRange = IsPlayerInRange();
    }
}
