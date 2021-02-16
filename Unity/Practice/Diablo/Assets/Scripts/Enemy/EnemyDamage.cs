using System.Collections;
using UnityEngine;

namespace Enemy {
    public class EnemyDamage : MonoBehaviour, IDamageable {
        [SerializeField] private float enemyHP = 50f;
        private float enemyCNTHP;

        private Animator animator;
        private Material enemy;
        private EnemyMovement enemyController;
        private CharacterController rigidBody;
        
        private void Start() {
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<CharacterController>();
            enemyCNTHP = enemyHP * GamePlayManager.instance.stageLV;
        }

        public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject) {
            if(animator.GetBool("Damage")) return false;
            
            if(enemyCNTHP - damageAmount <= 0) {
                enemyCNTHP = 0;
                Die();
                return true;
            }

            string[] animTitle = {"Male Damage Light", "Male Damage Heavy"};
            int animIndex = isKnockBack ? 1 : 0;
            
            enemyCNTHP -= damageAmount;
            enemyController.target = attackObject;
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex 
            ));
            return true;
        }

        public void Die() {
            StartCoroutine(DestroyObject());
        }

        private IEnumerator DestroyObject() {
            animator.Play("Base Layer.Male Die");
            rigidBody.gameObject.SetActive(false);
            
            for(int i = 255; i >= 0; i--) {
                enemy.color = new Color(1f, 1f, 1f, Mathf.Clamp(i, 0f, 1f));
                yield return new WaitForSeconds(0.02f);
            }
            
            //TODO: Drop pickable items.
            
            Destroy(gameObject);
        }
    }
}