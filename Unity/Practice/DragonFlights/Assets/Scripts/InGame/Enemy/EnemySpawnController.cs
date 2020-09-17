using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    private float dragonSpawnInterval = 3f;
    private float meteoSpawnInterval = 5f;
    private float bossSpawnInterval = 20f;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject meteoPrefab;
    [SerializeField] private GameObject bossPrefab;

    private GameObject player;

    private float dragonTimer;
    private float meteoTimer;
    private float bossTimer;

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    private void Update () {
        if (bossTimer >= bossSpawnInterval) {
            GamePlayManager.dontSpawn = true;
            var pos = new Vector3(transform.position.x, 7, 0);
            pos.x = 0; 
            Instantiate(bossPrefab, pos, Quaternion.identity);
            bossTimer -= bossSpawnInterval;
            bossSpawnInterval = Random.Range(17, 30);
        }

        if (!GamePlayManager.dontSpawn) {
            dragonTimer += Time.deltaTime;
            meteoTimer += Time.deltaTime;
            bossTimer += Time.deltaTime;

            if (dragonTimer >= dragonSpawnInterval) {
                GamePlayManager.dragonsCount = 5;
                foreach (var spawnPoint in spawnPoints) {
                    var enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                    var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

                    enemy.transform.parent = spawnPoint;
                }

                dragonTimer -= dragonSpawnInterval;
            }

            if (meteoTimer >= meteoSpawnInterval) {
                var pos = player.transform.position;
                pos.y = 11f;
                Instantiate(meteoPrefab, pos, Quaternion.identity);

                meteoTimer -= meteoSpawnInterval;
                meteoSpawnInterval = Random.Range(0.5f, 10f);
            }
        }
	}
}
