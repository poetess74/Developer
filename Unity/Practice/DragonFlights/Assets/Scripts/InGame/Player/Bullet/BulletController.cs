using UnityEngine;

public class BulletController : MonoBehaviour {
    private const float MAX_Y = 5.5f;

    private float speed = 36f;

    private void Update () {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= MAX_Y) {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (GamePlayManager.fireLevel <= 2) {
            if (collision.gameObject.CompareTag("Fire")) {
                Destroy(gameObject);
            }
        }
    }
}
