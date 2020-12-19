using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    private static GamePlayManager instance;

    private void Awake() {
        instance = this;
    }

    public static GamePlayManager Instance() {
        return GamePlayManager.instance;
    }
}
