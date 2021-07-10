using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Test {
    public class QuestionSpawner : MonoBehaviour {
        [Header("Question difficult type")]
        [SerializeField] private QuestionType question;

        [Header("Input UI Kit")]
        public Text firstNum;
        public Text operatorSymbol;
        public Text secondNum;

        [HideInInspector] public bool done = true;

        private void Update() {
            if(!done) return;

            switch(question) {
                case QuestionType.Basic:
                    ProvideNumber(1, 11);
                    OperatorType();
                    break;
                case QuestionType.Normal:
                    ProvideNumber(1, 100);
                    OperatorType();
                    break;
                case QuestionType.Hard:
                    ProvideNumber(1, 1000);
                    OperatorType();
                    break;
                case QuestionType.Expert:
                    ProvideNumber(1, 1000);
                    OperatorType();
                    break;
                case QuestionType.LevelTest:
                    throw new NotImplementedException();
            }
        }

        private void ProvideNumber(int min, int max) {
            firstNum.text = Random.Range(min, max).ToString();
            secondNum.text = Random.Range(min, max).ToString();
            done = false;
        }

        private void RebaseNumber() {
            int maxNum = Math.Max(int.Parse(firstNum.text), int.Parse(secondNum.text));
            int minNum = Math.Min(int.Parse(firstNum.text), int.Parse(secondNum.text));
            firstNum.text = maxNum.ToString();
            secondNum.text = minNum.ToString();
        }

        private void OperatorType() {
            int select = Random.Range(0, 5);
            switch(select) {
                case 0: operatorSymbol.text = "+"; break;
                case 1:
                    operatorSymbol.text = "-";
                    RebaseNumber();
                    break;
                case 2: operatorSymbol.text = "x"; break;
                case 3:
                    operatorSymbol.text = "÷";
                    RebaseNumber();
                    break;
                case 4:
                    operatorSymbol.text = "%";
                    RebaseNumber();
                    break;
            }
        }

        enum QuestionType {
            Basic, Normal, Hard, Expert, LevelTest
        }
    }
}
