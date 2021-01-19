using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject[] items;
    public Transform playerTransform;
    public float maxDistance = 5f;

    public float timeBetSpawnMax = 7f;
    public float timeBetSpawnMin = 2f;

    private float lastSpawnTime;

    private float timeBetSpawn;

    private void Start() {
    }

    private void Update() {
    }

    private void Spawn() {
    }
}