using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour {
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float maxDistance = 5f;

    [SerializeField] private float timeBetSpawnMax = 7f;
    [SerializeField] private float timeBetSpawnMin = 2f;

    private float lastSpawnTime;

    private float timeBetSpawn;

    private void Start() {
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0f;
    }

    private void Update() {
        if(!(Time.time >= lastSpawnTime + timeBetSpawn) || playerTransform == null) return;
        Spawn();
        lastSpawnTime = Time.time;
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
    }

    private void Spawn() {
        Vector3 spawnPosition = Utility.GetRandomPointOnNavMesh(
            playerTransform.position, maxDistance, NavMesh.AllAreas
        );
        spawnPosition += Vector3.up * 0.5f;
        GameObject item = Instantiate(items[Random.Range(0, items.Length)], spawnPosition, Quaternion.identity);
        Destroy(item, 5f);
    }
}