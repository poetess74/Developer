using UnityEngine;

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
    private PlayerShooter playerShooter;

    private float speedSmoothVelocity;
    private float turnSmoothVelocity;

    public float currentSpeed =>
        new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerShooter = GetComponent<PlayerShooter>();
        followCam = Camera.main;
    }

    private void Update() {
        UpdateAnimation(playerInput.moveInput);
    }

    private void FixedUpdate() {
        if(currentSpeed > 0.2f || playerInput.fire || playerShooter.aimState == PlayerShooter.AimState.HipFire) Rotate();

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
        float targetRotation = followCam.transform.eulerAngles.y;
        targetRotation = Mathf.SmoothDampAngle(
            transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime
        );
        transform.eulerAngles = Vector3.up * targetRotation;
    }

    public void Jump() {
        if(!characterController.isGrounded) return;
        currentVelocityY = jumpVelocity;
    }

    private void UpdateAnimation(Vector2 moveInput) {
        float animationSpeedRatio = currentSpeed / speed;
        animator.SetFloat("Horizontal Move", moveInput.x * animationSpeedRatio, 0.05f, Time.deltaTime);
        animator.SetFloat("Vertical Move", moveInput.y * animationSpeedRatio, 0.05f, Time.deltaTime);
    }
}