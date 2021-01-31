using UnityEngine;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        private float speed = 3f;
        
        private PlayerInput playerInput;
        private Animator animator;
        private Camera followCam;
        private CharacterController characterController;

        private float currentSpeed =>
            new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
    
        // Start is called before the first frame update
        private void Start() {
            playerInput = GetComponent<PlayerInput>();
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
            followCam = Camera.main;
        }

        // Update is called once per frame
        private void Update() {
            float animSpeedRatio = currentSpeed / speed;
            animator.SetFloat("Horizontal", playerInput.moveInput.x * animSpeedRatio, 0.05f, Time.deltaTime);
            animator.SetFloat("Vertical", playerInput.moveInput.y * animSpeedRatio, 0.05f, Time.deltaTime);
        }

        private void FixedUpdate() {
            float speed = this.speed * playerInput.moveInput.magnitude;
            Vector3 moveDir = Vector3.Normalize(
                transform.forward * playerInput.moveInput.y + transform.right * playerInput.moveInput.x
            );
            Vector3 velocity = moveDir * speed;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
