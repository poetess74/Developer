using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class QuestionStatus : MonoBehaviour {
        [SerializeField] private Text questionCount;
        [SerializeField] private Text performance;

        [HideInInspector] public bool maxAnswerCountReached;
        [HideInInspector] public int currentAnswerCount = 1;
        [HideInInspector] public int correctAnswerCount;

        private int providedAnswerCount;

        public void SetQuestionCount(int maxAnswerCount, bool init) {
            if(init) {
                correctAnswerCount = maxAnswerCount;

                providedAnswerCount = maxAnswerCount;
                questionCount.text = $"{maxAnswerCount}문항 중 {currentAnswerCount}번";

                return;
            }

            if(providedAnswerCount > currentAnswerCount) {
                currentAnswerCount++;

                questionCount.text = $"{maxAnswerCount}문항 중 {currentAnswerCount}번";
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
}
