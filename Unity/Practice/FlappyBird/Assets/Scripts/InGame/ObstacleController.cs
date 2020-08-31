using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    private void Update() {
        if(!GamePlayManager.isGameOver) {
            gameObject.transform.position += Vector3.left * GamePlayManager.scrollSpeed * Time.deltaTime;
        } else if(gameObject.transform.position.x >= Mathf.Abs(GamePlayManager.limitPosition)) {
            Destroy(gameObject);
        }
        if(gameObject.transform.position.x > GamePlayManager.limitPosition) return;
        Destroy(gameObject);
    }
}
