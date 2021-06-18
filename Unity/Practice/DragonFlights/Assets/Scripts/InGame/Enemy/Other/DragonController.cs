using UnityEngine;

public class DragonController : MonoBehaviour {
    private const float MIN_Y = -6f;

    [SerializeField] private float health = 1f;
    [SerializeField] private int score = 50;
    [SerializeField] private int hitScore = 25;

    private float speed = 3.3f;

    private float currentHealth;

	private void Start () {
        currentHealth = health;
	}

	private void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= MIN_Y) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Laser")) {
            return;
        }

        Destroy(collision.gameObject);

        currentHealth -= GamePlayManager.GetPlayerBulletDamage();

        GamePlayManager.AddScore(hitScore);
        if (currentHealth <= 0) {
            GamePlayManager.AddScore(score);
            Destroy(gameObject);
            GamePlayManager.dragonsCount--;
        }
    }
}