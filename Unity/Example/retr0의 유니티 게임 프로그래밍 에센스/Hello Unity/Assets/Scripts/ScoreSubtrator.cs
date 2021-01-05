using UnityEngine;

public class ScoreSubtrator : MonoBehaviour {
    private void Update() {
        if(!Input.GetMouseButtonDown(1)) return;
        ScoreManager.GetInstance().addScore(-2);
        Debug.Log(ScoreManager.GetInstance().getScore());
    }
}
