using UnityEngine;

public class BossController : MonoBehaviour {
    private const float MIN_Y = 2f;

    public float health = 200f;
    public int score = 300;
    public int hitScore = 150;

    private float currentHealth;
    private float speed = 2.5f;
    private bool down = true;
	
    private void Start () {
        this.currentHealth = this.health;
	}
	
	private void Update () {
        if (this.transform.position.y > MIN_Y) {
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
           
        } else {
            down = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) { 
        if (!down) {
            if (collision.gameObject.tag != "Laser") {
                return;
            }

            Destroy(collision.gameObject);

            this.currentHealth -= GamePlayManager.GetPlayerBulletDamage();
            GamePlayManager.AddScore(this.hitScore);
            if (this.currentHealth <= 0) {
                bool pending = true;
                int square = 0;
                int startRand = 0;
                int endRand = 0;
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
                GamePlayManager.AddScore(this.score);
                GamePlayManager.dontSpawn = false;

                Destroy(gameObject);

                square = GamePlayManager.fireLevel * GamePlayManager.fireLevel;
                this.health = GamePlayManager.score * rand * this.health;
                this.score = square * rand;
                this.hitScore = rand;

                pending = false;
                while (pending) {}
            }
        }
    }
}
