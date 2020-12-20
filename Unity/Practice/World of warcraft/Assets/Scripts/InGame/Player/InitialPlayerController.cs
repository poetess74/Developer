using UnityEngine;

public class InitialPlayerController : MonoBehaviour {
    private void Start() {
        if(GamePlayManager.PlayerLocation.y < 0) {
            transform.position = new Vector3(1f, 0f, 1f);
            GamePlayManager.PlayerLocation = transform.position;
        } else {
            transform.position = GamePlayManager.PlayerLocation;
        }
    }
}
