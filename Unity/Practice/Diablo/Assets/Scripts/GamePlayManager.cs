using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool hardInterrupt;
    [HideInInspector] public bool softInterrupt;
    [HideInInspector] public Difficulty difficulty;
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
        difficulty = Difficulty.Normal;
        enemies = GetDifficultRank() * 12;

        instance = this;
    }
}
