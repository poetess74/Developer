using UnityEngine;

public class DualshotController : MonoBehaviour {
    private const float MIN_Y = -6f;

    private float speed = 6f;

    private void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= MIN_Y) {
            Destroy(gameObject);
        }
    }
}
