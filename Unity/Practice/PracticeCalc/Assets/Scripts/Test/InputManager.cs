using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Test {
    public class InputManager : MonoBehaviour {
        [Header("User input UI")]
        public Text inputField;
        [SerializeField] private Button menu;
        [SerializeField] private AlertDialogController exitTest;
        [SerializeField] private AlertDialogController skipTest;

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

        public void NextQuestion() {
            skipTest.SetAlertDialog("계속 진행할 경우 다음 문제로 전환됨",
                "계속 진행할 경우 다음 문제로 진행하며 이로 인한 성적 불이익이 발생할 수 있습니다. \n \n(WRN-1029)",
                "계속", "유지", false, true, Color.red, Color.clear);
        }

        public void NextQuestionAlert() {
            skipTest.SetActiveAlertDialog(false);
            inputField.text = "-- 공 란 --";

            ShowResult();
        }

        public void AllClear(bool autoExecute) {
            if(status.maxAnswerCountReached) return;
            if(inputField.text == "0" && !autoExecute) {
                exitTest.SetAlertDialog("계속 진행할 경우 이전 화면으로 전환됨",
                    "계속 진행할 경우 홈으로 전환되며 추후 공개되는 문제는 이미 출제된 문제와 상이할 수 있습니다.\n \n(WRN-1502)",
                    "나가기", "취소", false, true, Color.red, Color.clear);
            } else {
                inputField.text = "0";
            }
        }

        public void GoMenu() {
            if(GameManager.instance.triedQuestion != 0) {
                GameManager.instance.triedQuestion += status.currentAnswerCount - 1;
                GameManager.instance.correctAnswer += Mathf.FloorToInt((status.correctAnswerCount * (status.currentAnswerCount - 1)) / (float) GameManager.instance.providedQuestionCount);
                GameManager.instance.performance = (float) GameManager.instance.correctAnswer / GameManager.instance.triedQuestion * 100;
                GameManager.instance.Save();
            }

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
            if(exitTest != null) exitTest.SetActiveAlertDialog(false);
            if(skipTest != null) skipTest.SetActiveAlertDialog(false);
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
