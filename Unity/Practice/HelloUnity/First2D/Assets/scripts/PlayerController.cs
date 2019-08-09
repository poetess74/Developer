using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D _rbody = null;

    void Start() {
        _rbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float speed = 0;
        if (Input.GetAxis("Horizontal") < 0) {
            speed = -5;
        } else if (Input.GetAxis("Horizontal") > 0) {
            speed = 5;
        }

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x + speed * Time.deltaTime, y, z);

        if (Input.GetButtonDown("Jump")) {
            _rbody.AddForce(new Vector2(0, 300));
        }

        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("FIRE!");
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Mob") {
            gameObject.SetActive(false);
        }
    }
}
