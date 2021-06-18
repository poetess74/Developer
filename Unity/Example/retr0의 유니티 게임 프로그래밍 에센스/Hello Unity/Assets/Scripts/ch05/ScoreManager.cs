using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager GetInstance() {
        if(instance == null) {
            instance = FindObjectOfType<ScoreManager>();
            if(instance != null) return instance;
            
            var container = new GameObject("ScoreManager");
            container.AddComponent<ScoreManager>();
        }
        return instance;
    }
    
    private int score;
    private static ScoreManager instance;

    private void Start() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
        }
    }

    public int getScore() {
        return score;
    }

    public void addScore(int score) {
        this.score += score;
    }
}
