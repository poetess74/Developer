using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    private static GamePlayManager instance;

    public static string PlayerName;
    public static int PlayerLV;
    public static float PlayerHP;
    public static float PlayerSP;
    public static float PlayerCNTHP;
    public static float PlayerCNTSP;
    public static string PlayerJob;
    public static float PlayerEXP;
    public static float PlayerCNTEXP;
    public static string[] PlayerSkill = new string[10];

    public static Vector3 PlayerLocation;

    public static string TargetName;
    public static int TargetLV;
    public static float TargetHP;
    public static float TargetSP;
    public static float TargetMAXHP;
    public static float TargetMAXSP;
    public static string TargetJob;

    private void Awake() {
        instance = this;
    }

    public static GamePlayManager Instance() {
        return GamePlayManager.instance;
    }
}
