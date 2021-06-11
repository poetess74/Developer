using System;
using UnityEngine;

namespace InGame.Player {
    public class PlayerMovement : MonoBehaviour {
        private float movingTime;
        private Vector3 moveDir;
        
        private PlayerInput playerInput;
        private Animator animator;
        private CharacterController characterController;
        private PlayerStatus status;

    
        private void Start() {
            playerInput = GetComponent<PlayerInput>();
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
            status = GetComponent<PlayerStatus>();
        }

        private void FixedUpdate() {
            if(animator.GetBool("Damage") || animator.GetBool("Attack") || GamePlayManager.instance.isGameOver) return;
            Rotate(playerInput.moveDir, playerInput.axisController);
            Move(playerInput.axisController);
        }

        private void Move(bool axis) {
            if(axis) {
                throw new NotImplementedException();
            } else {
                float distance = movingTime > 9f ? 0f : Vector3.Distance(transform.position, playerInput.moveDir);

                if(distance >= 0.1f) {
                    if(moveDir == playerInput.moveDir) {
                        movingTime += Time.deltaTime;
                    } else {
                        movingTime = 0f;
                        moveDir = playerInput.moveDir;
                    }

                    animator.SetFloat("Movement", distance, 0.05f, Time.deltaTime);

                    Vector3 direction = playerInput.moveDir - transform.position;
                    direction = Vector3.Normalize(direction);
                    characterController.Move(direction * Time.deltaTime * status.agility);
                } else {
                    animator.SetFloat("Movement", 0f);
                    if(moveDir != playerInput.moveDir) {
                        movingTime = 0f;
                    }
                }
            }
        }

        public void Rotate(Vector3 watchPos, bool axis) {
            if(axis) {
                throw new NotImplementedException();
            } else {
                Vector3 direction = watchPos - transform.position;
                Vector3 viewPoint = new Vector3(direction.x, 0f, direction.z);
                if(viewPoint == Vector3.zero) return;
                transform.rotation = Quaternion.LookRotation(viewPoint);
            }
        }
    }
}
