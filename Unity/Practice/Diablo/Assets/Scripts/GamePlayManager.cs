using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [HideInInspector] public bool isGameOver;

    private void Awake() {
        instance = this;
    }
}
