using UnityEngine;

public class General : MonoBehaviour {
    
    private static General instance;

    public static GameObject Target; // stored Name, MAX HP, CNT HP, Rank

    public static bool MessageShow;
    public static string MessageTitle;
    public static string MessageText;
    public static bool NextMessage;

    private void Awake () {
        instance = this;
    }

    public static General Instance () {
        return General.instance;
    }

    public void SwithCamera () {
        ShuttleDB.instance.ShuttleCamera.SetActive(!ShuttleDB.instance.ShuttleCamera.activeSelf);
        PlayerDB.instance.FPSCamera.SetActive(!PlayerDB.instance.FPSCamera.activeSelf);
        PlayerDB.isOnboard = !PlayerDB.instance.FPSCamera.activeSelf;
        PlayerDB.instance.fpsController.SetActive(!PlayerDB.instance.fpsController.activeSelf);

        //ShuttleDB.ShuttleCamera.SetActive(!ShuttleDB.ShuttleCamera.activeSelf);
        //PlayerDB.FPSCamera.SetActive(!PlayerDB.FPSCamera.activeSelf);
        //PlayerDB.isOnboard = !PlayerDB.FPSCamera.activeSelf;
        //PlayerDB.fpsController.SetActive(!PlayerDB.fpsController.activeSelf);
    }
}
