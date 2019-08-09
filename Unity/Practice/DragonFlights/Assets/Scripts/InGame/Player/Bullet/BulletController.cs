using UnityEngine;

public class BulletController : MonoBehaviour {
    private const float MAX_Y = 5.5f;

    private float speed = 36f;

    private void Update () {
        this.transform.position += Vector3.up * this.speed * Time.deltaTime;

        if (this.transform.position.y >= MAX_Y) {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (GamePlayManager.fireLevel <= 2) {
            if (collision.gameObject.tag == "Fire") {
                Destroy(this.gameObject);
            }
        }
    }
}
