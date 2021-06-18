using UnityEngine;

public class Player : MonoBehaviour {

    private void Start () {
        GamePlayManager.Destroyed = false;
    }

    private void LateUpdate () {
        if (GamePlayManager.ResetCTRL){
            GamePlayManager.Destroyed = true;
            GamePlayManager.ResetCTRL = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter (Collision col) {
        switch (col.gameObject.tag) {
            case "Untagged":
                break;
            case "Respawn":
                GamePlayManager.Destroyed = true;
                Destroy(gameObject);
                break;
            case "Finish":
                Debug.Log("Finish!");
                GamePlayManager.Destroyed = true;
                Destroy(gameObject);
                break;
        }
    }
}
