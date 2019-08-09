using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private Text distLabel = null;
    private Text scoreLabel = null;

    private float lastDistance = 0f;
    private int lastScore = 0;

    private void Start() {
        this.distLabel = this.transform.Find("dist").GetComponent<Text>();
        this.scoreLabel = this.transform.Find("score").GetComponent<Text>();
    }

    private void Update() {
        float dist = GamePlayManager.GetDistance();
        int score = GamePlayManager.GetScore();

        if (dist != this.lastDistance) {
            this.distLabel.text = string.Format("{0} km", dist.ToString("N2"));
            this.lastDistance = dist;
        }

        if (score != this.lastScore) {
            this.scoreLabel.text = score.ToString("D7");
            this.lastScore = score;
        }
    }
}
