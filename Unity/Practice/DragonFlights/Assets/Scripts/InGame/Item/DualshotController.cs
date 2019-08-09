using UnityEngine;

public class DualshotController : MonoBehaviour {
    private const float MIN_Y = -6f;

    private float speed = 6f;

    private void Update() {
        this.transform.position += Vector3.down * this.speed * Time.deltaTime;

        if (this.transform.position.y <= MIN_Y) {
            Destroy(this.gameObject);
        }
    }
}
