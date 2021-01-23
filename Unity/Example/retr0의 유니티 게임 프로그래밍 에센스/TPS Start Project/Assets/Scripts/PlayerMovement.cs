﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpVelocity = 20f;
    [Range(0.01f, 1f)] [SerializeField] private float airControlPercent;

    [SerializeField] private float speedSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    
    private Animator animator;
    private CharacterController characterController;

    private float currentVelocityY;

    private Camera followCam;
    private PlayerInput playerInput;

    private float speedSmoothVelocity;
    private float turnSmoothVelocity;

    public float currentSpeed =>
        new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        followCam = Camera.main;
    }

    private void Update() {
        UpdateAnimation(playerInput.moveInput);
    }

    private void FixedUpdate() {
        if(currentSpeed > 0.2f || playerInput.fire) Rotate();

        Move(playerInput.moveInput);

        if(playerInput.jump) Jump();
    }

    public void Move(Vector2 moveInput) {
        float targetSpeed = speed * moveInput.magnitude;
        Vector3 moveDir = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);

        float smoothTime = characterController.isGrounded ? speedSmoothTime : speedSmoothTime / airControlPercent;
        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, smoothTime);
        
        currentVelocityY += Time.deltaTime * Physics.gravity.y;
        Vector3 velocity = moveDir * targetSpeed + Vector3.up * currentVelocityY;

        characterController.Move(velocity * Time.deltaTime);

        if(characterController.isGrounded) currentVelocityY = 0;
    }

    public void Rotate() {
    }

    public void Jump() {
    }

    private void UpdateAnimation(Vector2 moveInput) {
    }
}