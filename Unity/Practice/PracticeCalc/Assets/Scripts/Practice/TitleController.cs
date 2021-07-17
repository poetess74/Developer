using UnityEngine;
using UnityEngine.UI;

namespace Practice {
    public class TitleController : MonoBehaviour {
        private void Start() {
            switch(GameManager.instance.question) {
                case GameManager.QuestionType.Basic: gameObject.GetComponent<Text>().text = "초심자 레벨"; break;
                case GameManager.QuestionType.Normal: gameObject.GetComponent<Text>().text = "초급 레벨"; break;
                case GameManager.QuestionType.Hard: gameObject.GetComponent<Text>().text = "중급 레벨"; break;
                case GameManager.QuestionType.Expert: gameObject.GetComponent<Text>().text = "고급 레벨"; break;
                case GameManager.QuestionType.LevelTest: gameObject.GetComponent<Text>().text = "레벨 테스트"; break;
            }
        }
    }
}
