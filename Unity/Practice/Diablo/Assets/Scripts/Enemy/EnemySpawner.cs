using UnityEngine;
using System.Collections.Generic;

namespace Enemy {
    public class EnemySpawner : MonoBehaviour {
        [Header("Enemy Gender")]
        [SerializeField] private GameObject male;
        [SerializeField] private GameObject female;
        
        [Header("Enemy Spawner Setting")]
        [SerializeField] private int enemyCount = 25;

        private float mapSize;
        private List<GameObject> enemies = new List<GameObject>();

        private void Awake() {
            Vector3 groundSize = GameObject.Find("Ground").transform.lossyScale * 5;
            mapSize = Mathf.Min(groundSize.x, groundSize.z);
        }
        
        private void Start() {
            for(int i = 0; i < enemyCount; i++) {
                var position = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
                enemies.Add(Instantiate(Random.Range(0, 2) == 0 ? male : female, position, Quaternion.identity));
            }
        }
    }
}
