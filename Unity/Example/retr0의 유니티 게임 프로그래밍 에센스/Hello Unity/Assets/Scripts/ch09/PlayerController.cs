using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    [SerializeField] private Transform target;
    
    // Start is called before the first frame update
    private void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetButtonDown("Jump")) {
            anim.SetTrigger("Jump");
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", verticalInput);
        anim.SetFloat("Direction", horizontalInput);
    }

    private void OnAnimatorIK(int layerIndex) {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.5f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.5f);
        
        anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);
        
        anim.SetLookAtWeight(1.0f);
        anim.SetLookAtPosition(target.position);
    }
}
