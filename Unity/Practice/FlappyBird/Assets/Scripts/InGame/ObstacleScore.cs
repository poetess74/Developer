using UnityEngine;

public class ObstacleScore : MonoBehaviour {
    private void Update() {
        gameObject.GetComponent<BoxCollider2D>().enabled = !GamePlayManager.IsGameOver;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!GamePlayManager.IsGameOver)
            GamePlayManager.Score++;
        if(GamePlayManager.bestScore >= GamePlayManager.Score) return;
        GamePlayManager.bestScore = GamePlayManager.Score;
        GamePlayManager.isBestScore = true;
    }
}
