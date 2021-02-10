using UnityEngine;

namespace Player {
    public class TargetSelector : MonoBehaviour {
        private CharacterController characterController;
    
        // Start is called before the first frame update
        private void Start() {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        private void Update() {
        
        }
    }
}
