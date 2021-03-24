using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [SerializeField] private int enemyCount;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool interrupt;
    [HideInInspector] public Difficulty difficulty = Difficulty.Normal;
    [HideInInspector] public int enemies;

    public enum Difficulty {
        Normal, Hard, Export, Master, Torment1, Torment2, Torment3, Torment4, Torment5
    }

    public byte GetDifficultRank() {
        return difficulty switch {
            Difficulty.Normal => 1,
            Difficulty.Hard => 2,
            Difficulty.Export => 4,
            Difficulty.Master => 8,
            Difficulty.Torment1 => 16,
            Difficulty.Torment2 => 32,
            Difficulty.Torment3 => 64,
            Difficulty.Torment4 => 128,
            Difficulty.Torment5 => 255
        };
    }

    private void Awake() {
        instance = this;
    }
}
