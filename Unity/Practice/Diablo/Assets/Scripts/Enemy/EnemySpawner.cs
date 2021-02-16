using UnityEngine;
using System.Collections.Generic;

namespace Enemy {
    public class EnemySpawner : MonoBehaviour {
        [Header("Enemy Gender")]
        [SerializeField] private GameObject male;
        [SerializeField] private GameObject female;
        
        [Header("Enemy Spawner Setting")]
        private List<GameObject> enemies = new List<GameObject>();
        private float mapSize;
       
        private void Start() {
            mapSize = GamePlayManager.instance.mapSize;
            CreateEnemy();
        }

        public void CreateEnemy() {
            enemies.Clear();
            for(int i = 0; i < GamePlayManager.instance.enemies; i++) {
                var position = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
                GameObject enemy = Instantiate(Random.Range(0, 2) == 0 ? male : female, position, Quaternion.identity, transform);
                enemy.tag = "Enemy";
                enemy.layer = 6;
                enemy.GetComponent<EnemyDamage>().enemyName = "Test";
                enemy.GetComponent<EnemyDamage>().enemyGroup = "Human";
                enemy.GetComponent<EnemyDamage>().enemyHP = Random.Range(GamePlayManager.instance.enemies,
                    GamePlayManager.instance.stageLV * GamePlayManager.instance.enemies);
                enemy.GetComponent<EnemyDamage>().expReward = Random.Range(0.0001f, 0.005f * GamePlayManager.instance.stageLV);
                enemies.Add(enemy);
            }
        }
    }
}
