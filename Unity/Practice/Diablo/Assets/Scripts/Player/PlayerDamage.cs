using UnityEngine;

namespace Player {
    public class PlayerDamage : MonoBehaviour, IDamageable {
        private float playerHP;

        private Animator animator;
        
        private void Start() {
            animator = GetComponent<Animator>();
        }

        private void Update() {
        
        }

        public void Damaged(float damageAmount, bool isKnockBack) {
            if(playerHP - damageAmount <= 0) {
                Die();
                return;
            }

            string[] animTitle = {"DAMAGED00", "DAMAGED01"};
            int animIndex = isKnockBack ? 1 : 0;
            
            playerHP -= damageAmount;
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex 
            ));
        }

        public void Die() {
            throw new System.NotImplementedException();
        }
    }
}
