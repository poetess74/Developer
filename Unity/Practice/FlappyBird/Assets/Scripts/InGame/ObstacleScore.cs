using UnityEngine;

public class ObstacleScore : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D other) {
        GamePlayManager.score++;
    }
}
