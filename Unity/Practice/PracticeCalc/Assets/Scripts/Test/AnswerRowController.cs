using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class AnswerRowController : MonoBehaviour {
        [SerializeField] private Text listID;
        [SerializeField] private Text question;
        [SerializeField] private Text answer;
        [SerializeField] private Image status;

        public string ValueMerger(int firstNum, string op, int secondNum) {
            return firstNum + " " + op + " " + secondNum;
        }

        public void SetRowElement(int id, string question, string answer, bool successful) {
            listID.text = id.ToString();
            this.question.text = question;
            this.answer.text = answer;
            status.color = successful ? Color.blue : Color.red;
        }
    }
}
