using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Player {
    public class PlayerAttack : MonoBehaviour {
        public List<GameObject> target { get; private set; }
        
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private LayerMask enemyFilter;
        
        private PlayerStatistics statistics;
        
        private void Start() {
            statistics = GetComponent<PlayerStatistics>();
            target = new List<GameObject>();
        }

        private void Update() {
            if(GamePlayManager.instance.isGameOver || GamePlayManager.instance.interrupt) return;
            
            if(Input.GetButtonDown("Fire1")) {
                GetEnemyHealth();
                
                foreach(GameObject enemy in target) {
                    enemy.GetComponent<IDamageable>().Damaged(statistics.strength, false, gameObject);
                }
            }
        }

        private void LateUpdate() {
            for(int i = 0; i < target.Count; i++) {
                if(target[i].GetComponent<EnemyDamage>().enemyCNTHP <= 0f) {
                    target.Remove(target[i]);
                }
            }
        }

        private void GetEnemyHealth() {
            target.Clear();
            
            var hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, maxDistance, enemyFilter);
            foreach(RaycastHit hit in hits) {
                if(hit.transform.GetComponent<EnemyDamage>().enemyCNTHP <= 0f) continue;
                
                target.Add(hit.transform.gameObject);
            }
        }
    }
}