using UnityEngine;

public class ObstacleController : MonoBehaviour {
    private void Update() {
        gameObject.transform.position += Vector3.left * GamePlayManager.scrollSpeed * Time.deltaTime;
        if(gameObject.transform.position.x > GamePlayManager.limitPosition) return;
        Destroy(gameObject);
    }
}
