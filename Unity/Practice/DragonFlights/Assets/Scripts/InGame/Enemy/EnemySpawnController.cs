using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    private float dragonSpawnInterval = 3f;
    private float meteoSpawnInterval = 5f;
    private float bossSpawnInterval = 20f;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject meteoPrefab;
    public GameObject bossPrefab;

    private GameObject player;

    private float dragonTimer = 0f;
    private float meteoTimer = 0f;
    private float bossTimer = 0f;

    private void Start() {
        this.player = GameObject.FindWithTag("Player");
    }

    private void Update () {
        if (this.bossTimer >= this.bossSpawnInterval) {
            GamePlayManager.dontSpawn = true;
            var pos = new Vector3(this.transform.position.x, 7, 0);
            pos.x = 0; 
            var boss = Instantiate(this.bossPrefab, pos, Quaternion.identity);
            this.bossTimer -= this.bossSpawnInterval;
            this.bossSpawnInterval = Random.Range(17, 30);
        }

        if (!GamePlayManager.dontSpawn) {
            this.dragonTimer += Time.deltaTime;
            this.meteoTimer += Time.deltaTime;
            this.bossTimer += Time.deltaTime;

            if (this.dragonTimer >= this.dragonSpawnInterval) {
                GamePlayManager.dragonsCount = 5;
                foreach (var spawnPoint in this.spawnPoints) {
                    var enemyPrefab = this.enemyPrefabs[Random.Range(0, this.enemyPrefabs.Length)];
                    var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

                    enemy.transform.parent = spawnPoint;
                }

                this.dragonTimer -= this.dragonSpawnInterval;
            }

            if (this.meteoTimer >= this.meteoSpawnInterval) {
                var pos = this.player.transform.position;
                pos.y = 11f;
                var meteo = Instantiate(this.meteoPrefab, pos, Quaternion.identity);

                this.meteoTimer -= this.meteoSpawnInterval;
                this.meteoSpawnInterval = Random.Range(0.5f, 10f);
            }
        }
	}
}
