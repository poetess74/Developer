using System.Collections;
using UnityChan;
using UnityEngine;

namespace Player {
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
            int animIndex = isKnockBack ? 1 : 0;
            
            status.healthPointCNT -= Mathf.RoundToInt(damageAmount);
            
            StartCoroutine(Utility.animPlayOneShot(
                animator, animTitle[animIndex], "Damage", "DmgAnim", animIndex 
            ));
            return true;
        }

        public void Die(GameObject expGiven) {
            GamePlayManager.instance.isGameOver = true;
            gameObject.tag = "Respawn";
            blinkEye.isActive = false;

            StartCoroutine(DestroyObject());
        }
        private IEnumerator DestroyObject() {
            animator.Play("Base Layer.Female Die");
            
            yield return new WaitForSeconds(10f);
            
            GameObject.Find("Character1_Reference").SetActive(false);
            GameObject.Find("mesh_root").SetActive(false);
        }

        public void Respawn() {
            GameObject.Find("Character1_Reference").SetActive(true);
            GameObject.Find("mesh_root").SetActive(true);
            
            gameObject.tag = "Respawn";
            blinkEye.isActive = true;
        }
    }
}
