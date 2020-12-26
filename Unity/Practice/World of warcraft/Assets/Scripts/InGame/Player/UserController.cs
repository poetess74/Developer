using UnityEngine;
public class UserController : MonoBehaviour {
    [SerializeField] private float jumpForce;

    private Animator animator;
    private Rigidbody rbody;
    private Transform mainCamera;

    private void Start() {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    private void FixedUpdate() {
        var velocityForward = new Vector3(rbody.velocity.x, 0, rbody.velocity.z).magnitude;

        animator.SetFloat("velocity.y", rbody.velocity.y);
        animator.SetFloat("velocity.forward", velocityForward);
        animator.SetBool("isBattle", GamePlayManager.isBattle);
    }

    private void Update() {
        var animState = animator.GetCurrentAnimatorStateInfo(0);
        bool airborne = animState.IsName("Base.JumpUp") || animState.IsName("Base.Fall") || animState.IsName("Base.Land");

        if (!airborne) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                rbody.AddForce(Vector3.up * jumpForce);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
                Vector3 movement = transform.forward * 5;
                
                rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
            } else if (Input.GetKey(KeyCode.W)) {
                Vector3 movement = transform.forward * 2;
                
                rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
            }
            
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
                Vector3 movement = -transform.forward * 5;
                
                rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
            } else if (Input.GetKey(KeyCode.S)) {
                Vector3 movement = -transform.forward * 2;
                
                rbody.velocity = new Vector3(movement.x, rbody.velocity.y, movement.z);
            }
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up * -90 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime);
        }
    }

    private void LateUpdate() {
        const float dist = 3f, height = 1.5f, rotate = 5f;
        float cntYAngle = Mathf.LerpAngle(mainCamera.eulerAngles.y, transform.eulerAngles.y, rotate * Time.deltaTime);
        Quaternion rotation = Quaternion.Euler(0, cntYAngle, 0);
        mainCamera.position = transform.position - (rotation * Vector3.forward * dist) + (Vector3.up * height);
        Vector3 targetPos = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z);
        mainCamera.LookAt(targetPos);
    }
}