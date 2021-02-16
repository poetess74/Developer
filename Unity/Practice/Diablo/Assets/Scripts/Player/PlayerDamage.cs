using UnityEngine;

namespace Player {
    public class PlayerDamage : MonoBehaviour, IDamageable {
        [SerializeField] private float playerHP = 50;
        private float playerCNTHP;

        private Animator animator;
        private PlayerMovement player;
        
        private void Start() {
            animator = GetComponent<Animator>();
            player = GetComponent<PlayerMovement>();
            playerCNTHP = playerHP * GamePlayManager.instance.stageLV;
        }

        public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject) {
            if(animator.GetBool("Damage")) return false;

            Vector3 convertedTargetPos = new Vector3(
                attackObject.transform.position.x, 0f, attackObject.transform.position.z
            );
            player.Rotate(convertedTargetPos);
            
            if(playerCNTHP - damageAmount <= 0) {
                playerCNTHP = 0;
                Die(null);
                return true;
            }

            string[] animTitle = {"DAMAGED00", "DAMAGED01"};
            int animIndex = isKnockBack ? 1 : 0;
            
            playerCNTHP -= damageAmount;
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex 
            ));
            return true;
        }

        public void Die(GameObject expGiven) {
            GamePlayManager.instance.isGameOver = true;
            animator.Play("Base Layer.Female Die");
        }
    }
}
