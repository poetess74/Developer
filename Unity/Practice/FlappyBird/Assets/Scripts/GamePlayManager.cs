using UnityEngine;

public class GamePlayManager : MonoBehaviour {
    private static uint score;
    public static uint bestScore;
    public static bool isBestScore;
    private static bool isGameOver;

    private static GameObject resultViewer;
    private static GameObject scoreViewer;
    public static bool IsGameOver {
        get => isGameOver;
        set {
            isGameOver = value;
            if (resultViewer == null)
                resultViewer = GameObject.Find("ResultViewer");
            if (scoreViewer == null)
                scoreViewer = GameObject.Find("ScoreViewer");
            resultViewer.SetActive(isGameOver);
            scoreViewer.SetActive(!isGameOver);
        }
    }

    public static uint Score {
        get => score;
        set {
            score = value;
            if (resultViewer == null)
                resultViewer = GameObject.Find("ResultViewer");
            if(scoreViewer == null) 
                scoreViewer = GameObject.Find("ScoreViewer");
            resultViewer.SetActive(isGameOver);
            scoreViewer.SetActive(!isGameOver);
        } 
    }

    public static float scrollSpeed;
    public static float limitPosition;

    public static void Reset() {
        score = 0;
        isBestScore = false;
        isGameOver = false;
        resultViewer = null;
    }
}
