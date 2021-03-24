using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [SerializeField] private int enemyCount;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool interrupt;
    [HideInInspector] public int stageLV = 1;
    [HideInInspector] public int playerLV = 1;
    [HideInInspector] public int enemies;

    private void Awake() {
        instance = this;
        enemies = enemyCount * stageLV;
    }
}
