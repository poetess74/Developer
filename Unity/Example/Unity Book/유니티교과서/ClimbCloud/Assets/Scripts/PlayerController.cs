using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rbody;
    Animator animator;

    private const float jumpForce = 390f;
    private const float walkForce = 15f;
    private const float limitSpeed = 1f;

	// Use this for initialization
	void Start () {
        this.rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.rbody.AddForce(transform.up * jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) { key = 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { key = -1; }

        float speed = Mathf.Abs(this.rbody.velocity.x);

        if (speed < limitSpeed) {
            this.rbody.AddForce(transform.right * key * walkForce);
        }

        if (key != 0) {
            transform.localScale = new Vector2(key, 1);
        }

        this.animator.speed = speed / 2f;
	}
}
