using UnityEngine;

namespace Enemy {
    public class EnemyDamage : MonoBehaviour, IDamageable {
        [SerializeField] private float enemyHP = 50f;
        private float enemyCNTHP;

        private Animator animator;
        
        private void Start() {
            animator = GetComponent<Animator>();
            enemyCNTHP = enemyHP;
        }

        public bool Damaged(float damageAmount, bool isKnockBack) {
            throw new System.NotImplementedException();
        }

        public void Die() {
            throw new System.NotImplementedException();
        }
    }
}