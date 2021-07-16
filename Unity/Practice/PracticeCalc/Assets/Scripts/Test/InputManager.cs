using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Test {
    public class InputManager : MonoBehaviour {
        [Header("User input UI")]
        public Text inputField;
        [SerializeField] private Button menu;

        private QuestionChecker checker;
        private QuestionStatus status;
        private AlertDialogController alert;

        private void Start() {
            checker = FindObjectOfType<QuestionChecker>();
            status = FindObjectOfType<QuestionStatus>();
            alert = FindObjectOfType<AlertDialogController>();
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
                alert.SetAlertDialog("계속 진행할 경우 이전 화면으로 전환됨 ",
                    "계속 진행할 경우 홈으로 전환되며 추후 공개되는 문제는 이미 출제된 문제와 상이할 수 있습니다.\n \n(WRN-1502)",
                    "나가기", "취소", false, true, Color.red, Color.clear);
            } else {
                inputField.text = "0";
            }
        }

        public void GoMenu() {
            GameManager.instance.triedQuestion += status.currentAnswerCount - 1;
            GameManager.instance.correctAnswer += Mathf.FloorToInt((status.correctAnswerCount * (status.currentAnswerCount - 1)) / (float) GameManager.instance.providedQuestionCount);
            GameManager.instance.performance = (float) GameManager.instance.correctAnswer / GameManager.instance.triedQuestion * 100;
            GameManager.instance.Save();

            SceneManager.LoadScene(0);
        }

        public void SaveAndQuit() {
            GameManager.instance.triedQuestion += GameManager.instance.providedQuestionCount;
            GameManager.instance.correctAnswer += status.correctAnswerCount;
            GameManager.instance.performance = (float) GameManager.instance.correctAnswer / GameManager.instance.triedQuestion * 100;
            GameManager.instance.Save();

            SceneManager.LoadScene(0);
        }

        public void SaveAndNext() {
            GameManager.instance.triedQuestion += GameManager.instance.providedQuestionCount;
            GameManager.instance.correctAnswer += status.correctAnswerCount;
            GameManager.instance.performance = (float) GameManager.instance.correctAnswer / GameManager.instance.triedQuestion * 100;
            GameManager.instance.Save();

            SceneManager.LoadScene(1);
        }

        public void NegativeButton() {
            alert.SetActiveAlertDialog(false);
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

            checker.CheckAnswer();
            AllClear(true);
        }
    }
}
