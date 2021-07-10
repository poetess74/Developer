using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class InputManager : MonoBehaviour {
        [Header("User input UI")]
        public Text inputField;

        private QuestionChecker checker;

        private void Start() {
            checker = FindObjectOfType<QuestionChecker>();
        }

        public void NumberKey(int number) {
            inputField.text = int.Parse(inputField.text += number.ToString()).ToString();
        }

        public void Dot() {
            inputField.text += ".";
        }

        public void AllClear() {
            inputField.text = "0";
        }

        public void BackSpace() {
            if(inputField.text.Length > 1) {
                inputField.text = inputField.text.Remove(inputField.text.Length - 1);
            } else {
                AllClear();
            }
        }

        public void ShowResult() {
            checker.checkAnswer();
            AllClear();
        }
    }
}
