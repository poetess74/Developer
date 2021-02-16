using UnityEngine;

namespace Player {
    public class PlayerAttack : MonoBehaviour {
        [SerializeField] private float strength;
            
        private PlayerInput input;
        
        private void Start() {
            input = GetComponent<PlayerInput>();
        }

        private void Update() {
            if(input.target == null) return;
            
            var targetHealth = input.target.GetComponent<IDamageable>();
            if(Input.GetKeyDown(KeyCode.Alpha1)) {
                targetHealth.Damaged(strength, false, gameObject);
            }
        }
    }
}