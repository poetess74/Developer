using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    public static uint score;
    public static float dist;
    private static bool isGameOver;

    private static GameObject resultViewer;
    public static bool IsGameOver {
        get => isGameOver;
        set {
            isGameOver = value;
            if (resultViewer == null)
                resultViewer = GameObject.Find("ResultViewer");
            resultViewer.SetActive(isGameOver);
        }
    }

    public static float scrollSpeed;
    public static float limitPosition;
}
