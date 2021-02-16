using System.Collections;
using UnityEngine;

namespace Enemy {
    public class EnemyDamage : MonoBehaviour, IDamageable {
        public string enemyName;
        public string enemyGroup;
        public float enemyHP;

        private Animator animator;
        private Material enemy;
        private EnemyMovement enemyController;
        private CharacterController rigidBody;
        
        private void Start() {
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<CharacterController>();
            enemyController = GetComponent<EnemyMovement>();
            enemyHP *= GamePlayManager.instance.stageLV;
            enemy = GetComponent<Material>();
        }

        public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject) {
            if(animator.GetBool("Damage")) return false;
            
            if(enemyHP - damageAmount <= 0) {
                enemyHP = 0;
                Die();
                return true;
            }

            string[] animTitle = {"Male Damage Light", "Male Damage Heavy"};
            int animIndex = isKnockBack ? 1 : 0;
            
            enemyHP -= damageAmount;
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