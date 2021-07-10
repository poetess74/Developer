using UnityEngine;
using UnityEngine.UI;

namespace Test {
    public class QuestionChecker : MonoBehaviour {
        [SerializeField] private GameObject rowPrefab;
        [SerializeField] private GameObject result;

        [HideInInspector] public bool correctAnswer;

        private QuestionSpawner spawner;
        private InputManager input;

        private void Start() {
            spawner = FindObjectOfType<QuestionSpawner>();
            input = FindObjectOfType<InputManager>();
        }

        public void checkAnswer() {
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
            spawner.done = true;
        }

        private void AnswerRowInit() {
            GameObject list = Instantiate(rowPrefab, result.transform, false);
            list.transform.SetParent(result.transform, false);
            list.transform.position = new Vector3(list.transform.position.x, list.transform.position.y - (28 * (result.transform.childCount - 1)), list.transform.position.z);

            string question = list.GetComponent<AnswerRowController>().ValueMerger(int.Parse(spawner.firstNum.text), spawner.operatorSymbol.text, int.Parse(spawner.secondNum.text));
            string answer = input.inputField.text;

            list.GetComponent<AnswerRowController>().SetRowElement(0, question, answer, correctAnswer);

            //TODO: ScrollRect Vector value set
            result.transform.parent.parent.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        }
    }
}
