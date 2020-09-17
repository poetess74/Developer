using UnityEngine;

public class BossController : MonoBehaviour {
    private const float MIN_Y = 2f;

    [SerializeField] private float health = 200f;
    [SerializeField] private int score = 300;
    [SerializeField] private int hitScore = 150;

    private float currentHealth;
    private float speed = 2.5f;
    private bool down = true;
	
    private void Start () {
        currentHealth = health;
	}
	
	private void Update () {
        if (transform.position.y > MIN_Y) {
            transform.position += Vector3.down * speed * Time.deltaTime;
           
        } else {
            down = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (!down) {
            if (!collision.gameObject.CompareTag("Laser")) {
                return;
            }

            Destroy(collision.gameObject);

            currentHealth -= GamePlayManager.GetPlayerBulletDamage();
            GamePlayManager.AddScore(hitScore);
            if (currentHealth <= 0) {
                bool pending;
                int square;
                int startRand;
                int endRand;
                if (GamePlayManager.fireLevel > 0) {
                    startRand = 500;
                    endRand = 1000;
                } else if (GamePlayManager.fireLevel > 20) {
                    startRand = 1000;
                    endRand = 1500;
                } else if (GamePlayManager.fireLevel > 60) {
                    startRand = 1500;
                    endRand = 2000;
                } else if (GamePlayManager.fireLevel <= 80) {
                    startRand = 2000;
                    endRand = 2500;
                } else {
                    GamePlayManager.fireLevel = 1;
                    startRand = 500;
                    endRand = 1000;
                }
                int rand = Random.Range(startRand, endRand);
                GamePlayManager.AddScore(score);
                GamePlayManager.dontSpawn = false;

                Destroy(gameObject);

                square = GamePlayManager.fireLevel * GamePlayManager.fireLevel;
                health = GamePlayManager.score * rand * health;
                score = square * rand;
                hitScore = rand;

                pending = false;
                while (pending) {}
            }
        }
    }
}
