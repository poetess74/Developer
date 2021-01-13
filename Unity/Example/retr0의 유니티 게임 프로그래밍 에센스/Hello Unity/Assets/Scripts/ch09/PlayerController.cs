using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator anim;
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
        anim.SetFloat("Speed", verticalInput);
    }
}
