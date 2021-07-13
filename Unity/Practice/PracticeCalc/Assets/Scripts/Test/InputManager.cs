using System;
using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class InputManager : MonoBehaviour {
        [Header("User input UI")]
        public Text inputField;
        [SerializeField] private Button menu;

        private QuestionChecker checker;
        private QuestionStatus status;

        private void Start() {
            checker = FindObjectOfType<QuestionChecker>();
            status = FindObjectOfType<QuestionStatus>();
        }

        private void Update() {
            if(menu == null) return;
            menu.transform.GetChild(0).GetComponent<Text>().text = inputField.text != "0" ? "AC" : "메뉴";
        }

        public void NumberKey(int number) {
            if(status.maxAnswerCountReached) return;
            if(inputField.text.Length == 9) return;

            inputField.text = int.Parse(inputField.text += number.ToString()).ToString();
        }

        public void Dot() {
            if(status.maxAnswerCountReached) return;

            inputField.text += ".";
        }

        public void AllClear(bool autoExecute) {
            if(inputField.text == "0" && !autoExecute) {
                throw new NotImplementedException();
            } else {
                inputField.text = "0";
            }
        }

        public void BackSpace() {
            if(inputField.text.Length > 1) {
                inputField.text = inputField.text.Remove(inputField.text.Length - 1);
            } else {
                AllClear(true);
            }
        }

        public void ShowResult() {
            if(status.maxAnswerCountReached) return;

            checker.checkAnswer();
            AllClear(true);
        }
    }
}
