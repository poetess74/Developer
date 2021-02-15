using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public int stageLV = 1;

    private void Awake() {
        instance = this;
    }
}
