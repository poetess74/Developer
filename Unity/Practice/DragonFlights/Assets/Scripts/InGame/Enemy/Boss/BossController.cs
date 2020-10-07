using UnityEngine;
using Random = UnityEngine.Random;

public class BossController : MonoBehaviour {
    private const float MIN_Y = 2f;

    [SerializeField] private float health = 200f;
    [SerializeField] private int score = 300;
    [SerializeField] private int hitScore = 150;

    private float currentHealth;
    private float speed = 2.5f;
    private bool isMoving = true;
	
    private void Start () {
        currentHealth = health;
	}
	
	private void Update () {
        if (transform.position.y > MIN_Y) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        } else {
            isMoving = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(isMoving) return;
        if (!collision.gameObject.CompareTag("Laser")) {
            return;
        }
        Destroy(collision.gameObject);
        currentHealth -= GamePlayManager.GetPlayerBulletDamage();
        GamePlayManager.AddScore(hitScore);
        
        if (currentHealth <= 0) {
            bool pending;
            int square;
            int bonus = BonusController();

            GamePlayManager.AddScore(score);
            GamePlayManager.dontSpawn = false;

            Destroy(GameObject.Find("Enemy_Bullets"));
            Destroy(gameObject);

            square = GamePlayManager.fireLevel * GamePlayManager.fireLevel;
            health = GamePlayManager.score * bonus * health;
            score = square * bonus;
            hitScore = bonus;

            pending = false;
            while (pending);
        }
    }

    private int BonusController() {
        int startRangeBonus, endRangeBonus;
        if (GamePlayManager.fireLevel < 7) {
            startRangeBonus = 500;
            endRangeBonus = 1000;
        } else if (GamePlayManager.fireLevel < 14) {
            startRangeBonus = 1000;
            endRangeBonus = 1500;
        } else if (GamePlayManager.fireLevel < 21) {
            startRangeBonus = 1500;
            endRangeBonus = 2000;
        } else if (GamePlayManager.fireLevel <= 30) {
            startRangeBonus = 2000;
            endRangeBonus = 2500;
        } else {
            GamePlayManager.fireLevel = 0;
            startRangeBonus = 500;
            endRangeBonus = 1000;
        }
        return Random.Range(startRangeBonus, endRangeBonus);        
    }
}
