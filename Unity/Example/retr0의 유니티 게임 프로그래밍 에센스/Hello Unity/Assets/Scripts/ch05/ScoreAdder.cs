using UnityEngine;

public class ScoreAdder : MonoBehaviour {

    private void Awake() {
        Debug.LogFormat("Start Score: {0}", ScoreManager.GetInstance().getScore());
    }
    
    private void Update() {
        if(!Input.GetMouseButtonDown(0)) return;
        ScoreManager.GetInstance().addScore(5);
        Debug.Log(ScoreManager.GetInstance().getScore());
    }
}
