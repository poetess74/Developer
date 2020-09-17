using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
    private const float MIN_Y = -5.5f;

    private float speed = 2f;
    //private float damage = 1f;

    private void Update () {
        var dir = this.transform.rotation * Vector3.down;
        transform.position += dir * speed * Time.deltaTime;

        if (transform.position.y <= MIN_Y) {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
