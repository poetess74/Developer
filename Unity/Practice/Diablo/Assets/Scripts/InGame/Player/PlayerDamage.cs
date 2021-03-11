using System.Collections;
using InGame.Enemy;
using UnityChan;
using UnityEngine;

namespace InGame.Player {
    public class PlayerDamage : MonoBehaviour, IDamageable {
        private Animator animator;
        private PlayerMovement player;
        private PlayerStatus status;
        private AutoBlink blinkEye;
        
        private void Start() {
            animator = GetComponent<Animator>();
            player = GetComponent<PlayerMovement>();
            status = GetComponent<PlayerStatus>();
            blinkEye = GetComponent<AutoBlink>();
        }

        public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject) {
            if(animator.GetBool("Damage")) return false;

            Vector3 convertedTargetPos = new Vector3(
                attackObject.transform.position.x, 0f, attackObject.transform.position.z
            );
            player.Rotate(convertedTargetPos);
            
            if(status.healthPointCNT - damageAmount <= 0) {
                status.healthPointCNT = 0;
                Die(null);
                return true;
            }

            string[] animTitle = {"DAMAGED00", "DAMAGED01"};
            bool convertedKnockBack;
            if(isKnockBack && attackObject.GetComponent<EnemyDamage>().enemyLV * 2 < GamePlayManager.instance.stageLV) {
                convertedKnockBack = Random.Range(0, 2) == 1;
            } else {
                convertedKnockBack = isKnockBack;
            }
            int animIndex = convertedKnockBack ? 1 : 0;
            
            status.healthPointCNT -= (damageAmount / status.defence);
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex, true
            ));
            return true;
        }

        public void Die(GameObject expGiven) {
            GamePlayManager.instance.isGameOver = true;
            gameObject.tag = "Respawn";
            blinkEye.isActive = false;

            StartCoroutine(Utility.animPlayOneShot(
                animator, "Female Die", "Die", "DieAnim", 1, false
            ));
        }

        public void Respawn() {
            blinkEye.isActive = true;
            animator.SetBool("Die", false);

            status.healthPointCNT = status.healthPoint;
            status.manaPointCNT = status.manaPoint;

            GamePlayManager.instance.isGameOver = false;

            gameObject.tag = "Player";
        }
    }
}
