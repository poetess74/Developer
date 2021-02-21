using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Player {
    public class PlayerAttack : MonoBehaviour {
        public List<GameObject> target { get; private set; }
        
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private LayerMask enemyFilter;
        
        private PlayerStatus status;
        private Animator animator;
        
        private void Start() {
            status = GetComponent<PlayerStatus>();
            target = new List<GameObject>();
            animator = GetComponent<Animator>();
        }

        private void Update() {
            if(GamePlayManager.instance.isGameOver || GamePlayManager.instance.interrupt || animator.GetBool("Damage")) return;
            if(Input.GetButtonDown("Fire1")) {
                status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 0.05f);
                
                GetEnemyHealth();
                foreach(GameObject enemy in target) {
                    enemy.GetComponent<IDamageable>().Damaged(status.strength, false, gameObject);
                }
            }
            if(Input.GetButtonDown("Fire2")) {
                status.healthPointCNT += Utility.remainResourceProcess(status.healthPoint, status.healthPointCNT, 5f);
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