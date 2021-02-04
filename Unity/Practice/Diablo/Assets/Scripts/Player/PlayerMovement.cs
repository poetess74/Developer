using System.Collections;
using UnityEngine;

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
            animator.SetFloat("Movement", playerInput.targetPos.magnitude * animSpeedRatio, 0.05f, Time.deltaTime);
        }

        private void FixedUpdate() {
            Rotate();
            Move();
        }

        private void LateUpdate() {
            idlingTime += Time.deltaTime;

            if(currentSpeed > 0.1f) {
                idlingTime = 0f;
                animator.SetBool("Rest", false);
                StopCoroutine("animPlayOneShot");
            }
            
            if(idlingTime < 10f) return;
            idlingTime = 0f;
            StartCoroutine(animPlayOneShot("Rest", 0));
        }

        private void Move() {
            float distance = Vector3.Distance(transform.position, playerInput.targetPos);
            if(distance >= 0.01f) {
                Vector3 direction = playerInput.targetPos - transform.position;
                direction = Vector3.Normalize(direction);
                characterController.Move(direction * Time.deltaTime * speed);
            }
        }

        private void Rotate() {
            Vector3 direction = playerInput.targetPos - transform.position;
            Vector3 viewPoint = new Vector3(direction.x, 0f, direction.z);
            transform.rotation = Quaternion.LookRotation(viewPoint);
        }

        private IEnumerator animPlayOneShot(string name, int index) {
            animator.SetBool(name, true);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(index).Length);
            animator.SetBool(name, false);
        }
    }
}
