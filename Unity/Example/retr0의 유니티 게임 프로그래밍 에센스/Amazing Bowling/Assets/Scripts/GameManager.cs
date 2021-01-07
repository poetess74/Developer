using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [Header("GameObject")]
    [SerializeField] private Camera cam;
    [SerializeField] private ShooterRotator shooterRotator;
    [Header("UI")]
    [SerializeField] private GameObject readyPane;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text messageText;

    private bool isRoundActive;
    private int score;
    private int bestScore;
    
    private void Awake() {
        instance = this;
        UpdateUI();
    }

    public void AddScore(int score) {
        this.score += score;
        bestScore = bestScore < score ? score : bestScore;
        UpdateUI();
    }

    private void UpdateUI() {
        scoreText.text = $"Score: {score}";
        bestScoreText.text = $"Score: {bestScore}";
    }

    public void OnBallDestroy() {
        UpdateUI();
        isRoundActive = false;
    }

    public void Reset() {
        score = 0;
        UpdateUI();
        
        //TODO: 라운드를 재시작
    }
}
