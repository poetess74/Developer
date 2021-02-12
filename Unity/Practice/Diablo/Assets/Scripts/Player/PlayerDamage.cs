using UnityEngine;

namespace Player {
    public class PlayerDamage : MonoBehaviour, IDamageable {
        private float playerHP;
        private void Start() {
        
        }

        private void Update() {
        
        }

        public void Damaged(float damageAmount, bool isKnockBack) {
            if(playerHP - damageAmount <= 0) {
                Die();
                return;
            }
            playerHP -= damageAmount;
        }

        public void Die() {
            throw new System.NotImplementedException();
        }
    }
}
