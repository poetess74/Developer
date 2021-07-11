using UnityEngine;
using UnityEngine.UI;

public class QuestionStatus : MonoBehaviour {
    [SerializeField] private Text questionCount;
    [SerializeField] private Text performance;

    [HideInInspector] public bool maxAnswerCountReached;
    [HideInInspector] public int currentAnswerCount = 1;

    private int providedAnswerCount;
    private int correctAnswerCount;

    public void SetQuestionCount(int maxAnswerCount, bool init) {
        providedAnswerCount = maxAnswerCount;
        questionCount.text = $"{maxAnswerCount}문항 중 {currentAnswerCount}번";
        if(init) {
            correctAnswerCount = maxAnswerCount;
            return;
        }

        if(providedAnswerCount > currentAnswerCount) {
            currentAnswerCount++;
        } else {
            maxAnswerCountReached = true;
        }
    }

    public void SetPerformance(bool correctAnswer) {
        if(!correctAnswer) {
            correctAnswerCount--;
        }

        float percent = (float) correctAnswerCount / providedAnswerCount * 100;
        performance.text = $"정확도: {percent:F2}%";
    }

    public void SetPerformance() {
        performance.text = "정확도: 100.00%";
    }
}
