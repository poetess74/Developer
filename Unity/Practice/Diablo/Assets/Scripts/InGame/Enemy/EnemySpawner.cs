using System.Collections.Generic;
using InGame.Player;
using Other;
using UnityEngine;

namespace InGame.Enemy {
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
            CreateEnemy("Human");
        }

        public void CreateEnemy(string enemyGroup) {
            for(int i = 0; i < GamePlayManager.instance.enemies; i++) {
                var position = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize)) + spawnPos.parent.position;
                GameObject enemy = Instantiate(Random.Range(0, 2) == 0 ? male : female, position, Quaternion.identity, transform);
                enemy.tag = "Enemy";
                enemy.layer = 6;
                enemy.GetComponent<EnemyDamage>().enemyName = $"{Utility.randomString(6)}";
                enemy.GetComponent<EnemyDamage>().enemyGroup = enemyGroup;
                enemy.GetComponent<EnemyDamage>().enemyHP = Random.Range(GamePlayManager.instance.enemies,
                    GamePlayManager.instance.GetDifficultRank() * GamePlayManager.instance.enemies);
                enemy.GetComponent<EnemyAttack>().enemyStrength = Random.Range(GamePlayManager.instance.GetDifficultRank(),
                    GamePlayManager.instance.GetDifficultRank() * 10);
                enemy.GetComponent<EnemyDamage>().expReward = Random.Range(2f, 10f * GamePlayManager.instance.GetDifficultRank());
                enemy.GetComponent<EnemyDamage>().enemyLV = GamePlayManager.instance.GetDifficultRank();
                enemies.Add(enemy);
            }
        }

        public bool RemoveEnemy() {
            int delFailCount = 0;
            int enemiesCount = enemies.Count;

            foreach(GameObject enemy in enemies) {
                if(enemy.GetComponent<EnemyDamage>().immune) {
                    delFailCount++;
                    continue;
                }

                enemy.GetComponent<EnemyDamage>().Damaged(
                    int.MaxValue, false, FindObjectOfType<PlayerEXP>().gameObject
                );
            }

            float failureRatio = (float) delFailCount / enemiesCount * 100;

            if(delFailCount == 0) return true;

            if(delFailCount != enemiesCount) {
                Debug.LogWarningFormat("patcher: Can not remove enemies (failed: {0:F2}%). because currently immune state. but some enemies will remove in 10 seconds.", failureRatio);
            }

            return delFailCount != enemiesCount;
        }
    }
}
