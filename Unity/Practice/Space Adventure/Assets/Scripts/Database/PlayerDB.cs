using UnityEngine;

public class PlayerDB : MonoBehaviour {
    public static PlayerDB instance;

    public static string playerName = "Test User";
    public static int playerHP = 50;
    public static int CNTPlayerHP = 50;
    public static int playerSP = 25;
    public static int CNTPlayerSP = 25;
    public static string playerRank = "T";

    public static float pressure = 1.0f;

    public static bool WeaponEnable;
    public static string WeaponName = "Basic laser";

    public static int sloatUnit = 4;
    public static int maxSloat = 32;
    public static int havingSloat = 32;
    public static int cntSloat = 4;

    public static bool Reload;

    public static bool communicationBool;
    public static bool Unable;
    public static bool Lock;

    public static bool isRunning;

    public static string whoIs;
    public static bool isOnboard;

    public GameObject FPSCamera;
    public GameObject fpsController;

    private void Awake () {
        instance = this;
    }

    public static PlayerDB Instance () {
        return PlayerDB.instance;
    }
}
