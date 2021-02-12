using UnityEngine;

namespace Player {
    public class TargetSelector : MonoBehaviour {
        private CharacterController characterController;
    
        private void Start() {
            characterController = GetComponent<CharacterController>();
        }

        private void Update() {
        
        }
    }
}
