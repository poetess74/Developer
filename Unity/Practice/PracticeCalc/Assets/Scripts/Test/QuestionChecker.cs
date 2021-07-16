using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class QuestionChecker : MonoBehaviour {
        [SerializeField] private GameObject rowPrefab;
        [SerializeField] private GameObject result;

        [HideInInspector] public bool correctAnswer;

        private QuestionSpawner spawner;
        private InputManager input;
        private QuestionStatus status;

        private bool isFull;

        private void Start() {
            spawner = FindObjectOfType<QuestionSpawner>();
            input = FindObjectOfType<InputManager>();
            status = FindObjectOfType<QuestionStatus>();

            status.SetQuestionCount(GameManager.instance.providedQuestionCount, true);
            status.SetPerformance();
        }

        public void CheckAnswer() {
            if(status.maxAnswerCountReached) return;

            switch(spawner.operatorSymbol.text) {
                case "+":
                    correctAnswer = int.Parse(spawner.firstNum.text) + int.Parse(spawner.secondNum.text) == int.Parse(input.inputField.text);
                    break;
                case "-":
                    correctAnswer = int.Parse(spawner.firstNum.text) - int.Parse(spawner.secondNum.text) == int.Parse(input.inputField.text);
                    break;
                case "x":
                    correctAnswer = int.Parse(spawner.firstNum.text) * int.Parse(spawner.secondNum.text) == int.Parse(input.inputField.text);
                    break;
                case "÷":
                    correctAnswer = int.Parse(spawner.firstNum.text) / int.Parse(spawner.secondNum.text) == int.Parse(input.inputField.text);
                    break;
                case "%":
                    correctAnswer = int.Parse(spawner.firstNum.text) % int.Parse(spawner.secondNum.text) == int.Parse(input.inputField.text);
                    break;
            }
            AnswerRowInit();
            status.SetQuestionCount(GameManager.instance.providedQuestionCount, false);
            status.SetPerformance(correctAnswer);
            spawner.done = true;
        }

        private void AnswerRowInit() {
            GameObject list = Instantiate(rowPrefab, result.transform, false);
            list.transform.SetParent(result.transform, false);
            list.transform.position = new Vector3(list.transform.position.x, list.transform.position.y - (28 * (result.transform.childCount - 1)), list.transform.position.z);

            string question = list.GetComponent<AnswerRowController>().ValueMerger(int.Parse(spawner.firstNum.text), spawner.operatorSymbol.text, int.Parse(spawner.secondNum.text));
            string answer = input.inputField.text;

            list.GetComponent<AnswerRowController>().SetRowElement(status.currentAnswerCount, question, answer, correctAnswer);

            var scrollViewBar = result.transform.parent.parent.GetComponent<ScrollRect>();
            if(result.transform.childCount > 4 && result.transform.childCount <= 10 && !isFull) {
                switch(result.transform.childCount) {
                    case 5: scrollViewBar.verticalNormalizedPosition = 0.84f; break;
                    case 6: scrollViewBar.verticalNormalizedPosition = 0.68f; break;
                    case 7: scrollViewBar.verticalNormalizedPosition = 0.52f; break;
                    case 8: scrollViewBar.verticalNormalizedPosition = 0.36f; break;
                    case 9: scrollViewBar.verticalNormalizedPosition = 0.20f; break;
                    case 10: scrollViewBar.verticalNormalizedPosition = 0.04f; break;
                }
            } else if(result.transform.childCount > 10 || isFull) {
                isFull = true;
                Destroy(result.transform.GetChild(0).gameObject);
                for(int i = 0; i < result.transform.childCount; i++) {
                    result.transform.GetChild(i).position = new Vector3(result.transform.GetChild(i).position.x, result.transform.GetChild(i).position.y + 28, result.transform.GetChild(i).position.z);
                }
                scrollViewBar.verticalNormalizedPosition = 0.04f;
            } else if(!isFull) {
                scrollViewBar.verticalNormalizedPosition = 1;
            }
        }
    }
}
