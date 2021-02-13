using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        private float speed = 3f;
        private float idlingTime;
        
        private PlayerInput playerInput;
        private Animator animator;
        private CharacterController characterController;

        private float currentSpeed =>
            new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
    
        private void Start() {
            playerInput = GetComponent<PlayerInput>();
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }

        private void Update() {
            float animSpeedRatio = currentSpeed / speed;
            animator.SetFloat("Movement", playerInput.moveDir.magnitude * animSpeedRatio, 0.05f, Time.deltaTime);
        }

        private void FixedUpdate() {
            if(animator.GetBool("Damage") || GamePlayManager.instance.isGameOver) return;
            Rotate();
            Move();
        }

        private void LateUpdate() {
            string[] idlingAnimClips = {"WAIT01", "WAIT02", "WAIT03", "WAIT04"};
            int idlingIndex = Random.Range(0, idlingAnimClips.Length);
            
            IEnumerator animController = Utility.animPlayOneShot(
                animator, idlingAnimClips[idlingIndex], "Rest", "IdleAnim", idlingIndex
            );
            
            idlingTime += Time.deltaTime;

            if(animator.GetBool("Damage") || currentSpeed > 0.1f || GamePlayManager.instance.isGameOver) {
                idlingTime = 0f;
                animator.SetBool("Rest", false);
                StopCoroutine(animController);
            }

            if(idlingTime < 120f) return;
            idlingTime = 0f;
            StartCoroutine(animController);
        }

        private void Move() {
            float distance = Vector3.Distance(transform.position, playerInput.moveDir);
            if(distance >= 0.01f) {
                Vector3 direction = playerInput.moveDir - transform.position;
                direction = Vector3.Normalize(direction);
                characterController.Move(direction * Time.deltaTime * speed);
            }
        }

        private void Rotate() {
            Vector3 direction = playerInput.moveDir - transform.position;
            Vector3 viewPoint = new Vector3(direction.x, 0f, direction.z);
            if(viewPoint == Vector3.zero) return;
            transform.rotation = Quaternion.LookRotation(viewPoint);
        }
    }
}
