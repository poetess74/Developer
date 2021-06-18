using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private Text distLabel;
    private Text scoreLabel;

    private float lastDistance;
    private int lastScore;

    private void Start() {
        distLabel = transform.Find("dist").GetComponent<Text>();
        scoreLabel = transform.Find("score").GetComponent<Text>();
    }

    private void Update() {
        float dist = GamePlayManager.GetDistance();
        int score = GamePlayManager.GetScore();

        if (Math.Abs(dist - lastDistance) > float.Epsilon) {
            distLabel.text = string.Format("{0} km", dist.ToString("N2"));
            lastDistance = dist;
        }

        if (score != lastScore) {
            scoreLabel.text = score.ToString("D7");
            lastScore = score;
        }
    }
}
