using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Player;

    private void Start () {
        Instantiate(Player);
    }

    private void LateUpdate () {
        if (GamePlayManager.Destroyed && 
            (GamePlayManager.Control_X < 3 ||
             GamePlayManager.Control_X > 357) &&
            (GamePlayManager.Control_Z < 3 ||
             GamePlayManager.Control_Z > 357)) 
        {
            Instantiate(Player);
        }
    }
}
