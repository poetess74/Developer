using UnityEngine;

public class ShuttleDB : MonoBehaviour {
    public static ShuttleDB instance;

    public static bool TutorialShuttleReChat;
    public GameObject ShuttleCamera;

    public static float shuttleSpeed;
    public static float shuttleAltitude;
    public static float shuttleFuel;
    public static float shuttleAngle;

    private void Awake () {
        instance = this;
    }

    public static ShuttleDB Instance () {
        return ShuttleDB.instance;
    }
}
