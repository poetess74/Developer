using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static int playerHP = 5000;
    public static int CNTPlayerHP = 5000;
    public static int playerSP = 1000;
    public static int CNTPlayerSP = 1000;

    public static bool WeaponEnable;

    public static int allSloat = 14000;
    public static int cntSloat = 14000;

    public static bool communicationBool;
    public static bool Unable;
    public static bool Lock;

    public static bool isRunning;

    public static bool Reload;
    public static bool UnableLaunch;

    public static bool MessageShow;
    public static string MessageTitle;
    public static string MessageText;
    public static bool NextMessage;

    public static string whoIs;

    public static bool HelperReChat;
    public static bool TutorialShuttleReChat;

    public GameObject ShuttleCamera;
    public GameObject fpsController;

    public static float shuttleSpeed;
    public static float shuttleAltitude;
    public static float shuttleFuel;
    public static float shuttleAngle;

    private static GamePlayManager instance;

    private void Awake () {
        instance = this;
    }

    public static GamePlayManager Instance () {
        return GamePlayManager.instance;
    }

    public void SwithCamera () {
        ShuttleCamera.SetActive(!ShuttleCamera.activeSelf);
        fpsController.SetActive(!fpsController.activeSelf);
    }
}
