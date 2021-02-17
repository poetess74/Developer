using Enemy;
using UnityEngine;

namespace Player {
    public class PlayerAttack : MonoBehaviour {
        private PlayerInput input;
        private PlayerStatus status;
        
        private void Start() {
            input = GetComponent<PlayerInput>();
            status = GetComponent<PlayerStatus>();
        }

        private void Update() {
            if(input.target == null || GamePlayManager.instance.isGameOver) return;
            
            var targetHealth = input.target.GetComponent<IDamageable>();
            if(Input.GetKeyDown(KeyCode.Alpha1)) {
                if(input.target.GetComponent<EnemyDamage>().enemyCNTHP <= 0f) return;
                
                targetHealth.Damaged(status.strength, false, gameObject);
            }
        }
    }
}