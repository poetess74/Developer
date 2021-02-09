using System;
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
            IEnumerator animController = animPlayOneShot("WAIT01", "Rest");
            
            idlingTime += Time.deltaTime;

            if(currentSpeed > 0.1f) {
                idlingTime = 0f;
                animator.SetBool("Rest", false);
                StopCoroutine(animController);
            }
            
            if(idlingTime < 10f) return;
            idlingTime = 0f;
            StartCoroutine(animController);
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

        private IEnumerator animPlayOneShot(string clipName, string valueName) {
            int index = int.MinValue;
            var clips = animator.runtimeAnimatorController.animationClips;

            for(int i = 0; i < clips.Length; i++) {
                if(clips[i].name == clipName) {
                    index = i;
                    break;
                }
            }

            if(index == int.MinValue) {
                for(int i = 0; i < clips.Length; i++) {
                    Debug.LogFormat("index: {0}, name: {1}", i, clips[i].name);
                }
                
                animator.SetBool(valueName, false);
                throw new NullReferenceException(
                    "AnimationClip " + clipName + "(" + valueName + ")" + " does not match in Animator attached clips. Please check parameter again."
                );
            }

            animator.SetBool(valueName, true);
            Debug.LogFormat("Selected \"{0}\" AnimationClip(index: {1}/{2}), Clip duration: {3}", clips[index].name, index, clips.Length - 1, clips[index].length);
            yield return new WaitForSeconds(clips[index].length);
            animator.SetBool(valueName, false);
            
        }
    }
}
