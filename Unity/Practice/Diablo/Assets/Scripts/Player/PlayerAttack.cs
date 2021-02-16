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
            if(input.target == null) return;
            
            var targetHealth = input.target.GetComponent<IDamageable>();
            if(Input.GetKeyDown(KeyCode.Alpha1)) {
                targetHealth.Damaged(status.strength, false, gameObject);
            }
        }
    }
}