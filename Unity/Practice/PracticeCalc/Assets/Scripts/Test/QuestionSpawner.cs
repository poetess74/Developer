using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Test {
    public class QuestionSpawner : MonoBehaviour {
        [Header("Question difficult type")]
        [SerializeField] private QuestionType question;

        [Header("Input UI Kit")]
        [SerializeField] private Text firstNum;
        [SerializeField] private Text operatorSymbol;
        [SerializeField] private Text secondNum;

        [HideInInspector] public bool done = true;

        private void Update() {
            if(!done) return;

            switch(question) {
                case QuestionType.Basic:
                    OperatorType();
                    ProvideNumber(1, 11);
                    break;
                case QuestionType.Normal:
                    OperatorType();
                    ProvideNumber(1, 100);
                    break;
                case QuestionType.Hard:
                    OperatorType();
                    ProvideNumber(1, 1000);
                    break;
                case QuestionType.Expert:
                    OperatorType();
                    ProvideNumber(1, 1000);
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

        private void OperatorType() {
            int select = Random.Range(0, 5);
            switch(select) {
                case 0: operatorSymbol.text = "+"; break;
                case 1: operatorSymbol.text = "-"; break;
                case 2: operatorSymbol.text = "x"; break;
                case 3: operatorSymbol.text = "÷"; break;
                case 4: operatorSymbol.text = "%"; break;
            }
        }

        enum QuestionType {
            Basic, Normal, Hard, Expert, LevelTest
        }
    }
}
