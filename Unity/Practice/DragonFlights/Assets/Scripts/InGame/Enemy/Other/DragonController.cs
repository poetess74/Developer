using UnityEngine;

public class DragonController : MonoBehaviour {
    private const float MIN_Y = -6f;

    public float health = 1f;
    public int score = 50;
    public int hitScore = 25;

    private float speed = 3.3f;

    private float currentHealth;

	private void Start () {
        this.currentHealth = this.health;
	}

	private void Update () {
        this.transform.position += Vector3.down * this.speed * Time.deltaTime;

        if (this.transform.position.y <= MIN_Y) {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "Laser") {
            return;
        }

        Destroy(collision.gameObject);

        this.currentHealth -= GamePlayManager.GetPlayerBulletDamage();

        GamePlayManager.AddScore(this.hitScore);
        if (this.currentHealth <= 0) {
            GamePlayManager.AddScore(this.score);
            Destroy(gameObject);
            GamePlayManager.dragonsCount--;
        }
    }
}