using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {
    private Vector2 velocity;

    void Start() {
        velocity = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
    }

    void Update() {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x + velocity.x * Time.deltaTime, y + velocity.y * Time.deltaTime, z);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Base_Top") {
            velocity.y = -velocity.y;
        } else if (col.gameObject.tag == "Base_Bottom") {
            velocity.y = -velocity.y;
        } else if (col.gameObject.tag == "Base_Left") {
            velocity.x = -velocity.x;
        } else if (col.gameObject.tag == "Base_Right") {
            velocity.x = -velocity.x;
        }
    }
}
