using UnityEngine;
using UnityEngine.SceneManagement;

namespace Home {
    public class InputManager : MonoBehaviour {
        private AlertDialogController alert;

        private void Start() {
            alert = FindObjectOfType<AlertDialogController>();
        }

        public void StartTest(string method) {
            switch(method) {
                case "Basic":
                    GameManager.instance.question = GameManager.QuestionType.Basic;
                    alert.SetAlertDialog("연습을 시작합니다. ", $"초심자 난이도로 {GameManager.instance.providedQuestionCount} 문제를 출제할 예정입니다. \n범위: 1에서 10까지 자연수 사칙연산", "승인", "취소");
                    break;
                case "Normal":
                    GameManager.instance.question = GameManager.QuestionType.Normal;
                    alert.SetAlertDialog("연습을 시작합니다. ", $"초급 난이도로 {GameManager.instance.providedQuestionCount} 문제를 출제할 예정입니다. \n범위: 최대 두 자리 자연수 사칙연산", "승인", "취소");
                    break;
                case "Hard":
                    GameManager.instance.question = GameManager.QuestionType.Hard;
                    alert.SetAlertDialog("연습을 시작합니다. ", $"중급 난이도로 {GameManager.instance.providedQuestionCount} 문제를 출제할 예정입니다. \n범위: 최대 세 자리 자연수 사칙연산", "승인", "취소");
                    break;
                case "Expert":
                    GameManager.instance.question = GameManager.QuestionType.Expert;
                    alert.SetAlertDialog("연습을 시작합니다. ", $"고급 난이도로 {GameManager.instance.providedQuestionCount} 문제를 출제할 예정입니다. \n범위: 최대 네 자리 자연수 사칙연산", "승인", "취소");
                    break;
                case "Test":
                    GameManager.instance.question = GameManager.QuestionType.LevelTest;
                    alert.SetAlertDialog("테스트를 시작합니다. ", "테스트 진행중에는 계산기를 사용하지 마시기 바랍니다. ", "승인", "취소");
                    break;
            }

        }

        public void OpenSetting() {
            GameManager.instance.Save();

            SceneManager.LoadScene(2);
        }

        public void PositiveButton() {
            GameManager.instance.Save();

            SceneManager.LoadScene(1);
        }

        public void NegativeButton() {
            alert.SetActiveAlertDialog(false);
        }
    }
}
