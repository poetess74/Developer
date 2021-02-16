using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [SerializeField] private int enemyCount;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public int stageLV = 1;
    [HideInInspector] public float mapSize;
    [HideInInspector] public int enemies;

    private void Awake() {
        instance = this;
        
        Vector3 groundSize = GameObject.Find("Ground").transform.lossyScale * 5;
        mapSize = Mathf.Min(groundSize.x, groundSize.z);

        enemies = enemyCount * stageLV;
    }
}
