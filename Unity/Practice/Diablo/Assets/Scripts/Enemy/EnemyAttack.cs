using UnityEngine;

namespace Enemy {
    public class EnemyAttack : MonoBehaviour {
        public float enemyStrength;
        
        private EnemyMovement direction;
        private Animator animator;

        private void Start() {
            direction = GetComponent<EnemyMovement>();
            animator = GetComponent<Animator>();
        }

        private void Update() {
            if(animator.GetBool("Attack")) return;
            if(direction.target != null && direction.targetHealth != null && direction.state == EnemyMovement.CurrentState.attack) {
                int attackSkill = Random.Range(0, 3);
                string[] animClip = {"Male Attack 1", "Male Attack 2", "Male Attack 3"};
                StartCoroutine(
                    Utility.animPlayOneShot(animator, animClip[attackSkill], "Attack", "AttackType", attackSkill)
                );
                direction.targetHealth.Damaged(enemyStrength, animClip[attackSkill] == "Male Attack 2", gameObject);
            }
        }
    }
}
