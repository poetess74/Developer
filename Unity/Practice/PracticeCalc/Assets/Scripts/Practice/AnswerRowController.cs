using UnityEngine;
using UnityEngine.UI;

namespace Practice {
    public class AnswerRowController : MonoBehaviour {
        [SerializeField] private Text listID;
        [SerializeField] private Text question;
        [SerializeField] private Text answer;
        [SerializeField] private Image status;

        public string ValueMerger(int firstNum, string op, int secondNum) {
            return firstNum + " " + op + " " + secondNum;
        }

        public void SetRowElement(int id, string question, int inputAnswer, int correctAnswer) {
            listID.text = id.ToString();
            this.question.text = question;
            if(inputAnswer == int.MinValue) {
                answer.text = $"[공란] → {correctAnswer}";
            } else {
                answer.text = inputAnswer == correctAnswer ? $"{inputAnswer}" : $"{inputAnswer} → {correctAnswer}";
            }
            status.color = inputAnswer == correctAnswer ? Color.blue : Color.red;
        }
    }
}
