using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [Header("InGame")]
    [SerializeField] private CamFollow cam;
    [SerializeField] private ShooterRotator shooterRotator;
    [SerializeField] private UnityEvent onReset;
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

    private void Start() {
        StartCoroutine(RoundRoutine());
    }

    public void AddScore(int score) {
        this.score += score;
        bestScore = bestScore < this.score ? this.score : bestScore;
        UpdateUI();
    }

    private void UpdateUI() {
        scoreText.text = $"Score: {score}";
        bestScoreText.text = $"Best Score: {bestScore}";
    }

    public void OnBallDestroy() {
        UpdateUI();
        isRoundActive = false;
    }

    public void Reset() {
        score = 0;
        UpdateUI();
        
        //Round 재시작
        StartCoroutine(RoundRoutine());
    }

    private IEnumerator RoundRoutine() {
        //READY
        onReset.Invoke();
        readyPane.SetActive(true);
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Idle);
        shooterRotator.enabled = false;
        isRoundActive = false;
        messageText.text = "Ready...";
        yield return new WaitForSeconds(3f);
        //PLAY
        readyPane.SetActive(false);
        isRoundActive = true;
        shooterRotator.enabled = true;
        cam.SetTarget(shooterRotator.transform, CamFollow.State.Ready);
        while(isRoundActive) yield return null;
        //END
        readyPane.SetActive(true);
        shooterRotator.enabled = false;
        messageText.text = "Wait For Next Round...";
        yield return new WaitForSeconds(3f);
        Reset();
    }
}
