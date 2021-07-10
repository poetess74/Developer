using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class InputManager : MonoBehaviour {
        [Header("User input UI")]
        public Text inputField;

        [HideInInspector] public bool correctAnswer;

        private QuestionSpawner question;

        private void Start() {
            question = FindObjectOfType<QuestionSpawner>();
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
            switch(question.operatorSymbol.text) {
                case "+":
                    correctAnswer = int.Parse(question.firstNum.text) + int.Parse(question.secondNum.text) == int.Parse(inputField.text);
                    break;
                case "-":
                    correctAnswer = int.Parse(question.firstNum.text) - int.Parse(question.secondNum.text) == int.Parse(inputField.text);
                    break;
                case "x":
                    correctAnswer = int.Parse(question.firstNum.text) * int.Parse(question.secondNum.text) == int.Parse(inputField.text);
                    break;
                case "÷":
                    correctAnswer = int.Parse(question.firstNum.text) / int.Parse(question.secondNum.text) == int.Parse(inputField.text);
                    break;
                case "%":
                    correctAnswer = int.Parse(question.firstNum.text) % int.Parse(question.secondNum.text) == int.Parse(inputField.text);
                    break;
            }
            question.done = true;
            AllClear();
        }
    }
}
