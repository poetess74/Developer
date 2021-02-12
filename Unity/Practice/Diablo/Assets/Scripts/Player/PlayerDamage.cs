using UnityEngine;

namespace Player {
    public class PlayerDamage : MonoBehaviour, IDamageable {
        [SerializeField] private float playerHP = 50;
        private float playerCNTHP;

        private Animator animator;
        
        private void Start() {
            animator = GetComponent<Animator>();
            playerCNTHP = playerHP;
        }

        public void Damaged(float damageAmount, bool isKnockBack) {
            if(playerCNTHP - damageAmount <= 0) {
                playerCNTHP = 0;
                Die();
                return;
            }

            string[] animTitle = {"DAMAGED00", "DAMAGED01"};
            int animIndex = isKnockBack ? 1 : 0;
            
            playerCNTHP -= damageAmount;
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex 
            ));
        }

        public void Die() {
            GamePlayManager.instance.isGameOver = true;
            animator.Play("Base Layer.LOSE00");
        }
    }
}
