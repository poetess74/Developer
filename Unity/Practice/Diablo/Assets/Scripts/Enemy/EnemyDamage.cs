using System.Collections;
using Player;
using UnityEngine;

namespace Enemy {
    public class EnemyDamage : MonoBehaviour, IDamageable {
        public string enemyName;
        public string enemyGroup;
        public float enemyHP;
        public float enemyCNTHP;
        public float expReward;

        private Animator animator;
        private EnemyMovement enemyController;
        private PlayerEXP playerEXP;
        private EnemySpawner spawner;
        
        private void Start() {
            animator = GetComponent<Animator>();
            enemyController = GetComponent<EnemyMovement>();
            spawner = FindObjectOfType<EnemySpawner>();
            enemyCNTHP = enemyHP;
        }

        public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject) {
            if(animator.GetBool("Damage")) return false;
            
            if(enemyCNTHP - damageAmount <= 0) {
                enemyCNTHP = 0;
                Die(attackObject);
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

        public void Die(GameObject expGiven) {
            StartCoroutine(DestroyObject());
            
            expGiven.GetComponent<PlayerEXP>().AddPlayerEXP(enemyHP * expReward);
        }

        private IEnumerator DestroyObject() {
            enemyController.state = EnemyMovement.CurrentState.die;
            animator.Play("Base Layer.Male Die");

            //TODO: Drop pickable items.
            
            yield return new WaitForSeconds(10f);
            
            spawner.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}