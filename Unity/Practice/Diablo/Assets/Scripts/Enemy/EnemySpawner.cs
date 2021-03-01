using UnityEngine;
using System.Collections.Generic;

namespace Enemy {
    public class EnemySpawner : MonoBehaviour {
        public List<GameObject> enemies { get; private set; }
        
        public float mapSize { get; private set; }
        public Transform spawnPos { get; private set; }

        [Header("Enemy Gender")]
        [SerializeField] private GameObject male;
        [SerializeField] private GameObject female;

        private Vector3 groundScale;
       
        private void Start() {
            spawnPos = transform.parent.transform;
            groundScale = spawnPos.lossyScale * 5;
            mapSize = Mathf.Min(groundScale.x, groundScale.z);
            
            enemies = new List<GameObject>();
            CreateEnemy();
        }

        public void CreateEnemy() {
            for(int i = 0; i < GamePlayManager.instance.enemies; i++) {
                var position = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize)) + spawnPos.parent.position;
                GameObject enemy = Instantiate(Random.Range(0, 2) == 0 ? male : female, position, Quaternion.identity, transform);
                enemy.tag = "Enemy";
                enemy.layer = 6;
                enemy.GetComponent<EnemyDamage>().enemyName = "Test";
                enemy.GetComponent<EnemyDamage>().enemyGroup = "Human";
                enemy.GetComponent<EnemyDamage>().enemyHP = Random.Range(GamePlayManager.instance.enemies,
                    GamePlayManager.instance.stageLV * GamePlayManager.instance.enemies);
                enemy.GetComponent<EnemyAttack>().enemyStrength = Random.Range(GamePlayManager.instance.stageLV,
                    GamePlayManager.instance.stageLV * 10);
                enemy.GetComponent<EnemyDamage>().expReward = Random.Range(2f, 10f * GamePlayManager.instance.stageLV);
                enemy.GetComponent<EnemyDamage>().enemyLV = GamePlayManager.instance.stageLV;
                enemies.Add(enemy);
            }
        }

        public void RemoveEnemy() {
            foreach(GameObject target in enemies) {
                Destroy(target);
            }
            enemies.Clear();
        }
    }
}
