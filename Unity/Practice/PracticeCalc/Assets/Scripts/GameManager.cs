using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [HideInInspector] public QuestionType question;

    [HideInInspector] public int providedQuestionCount;
    [HideInInspector] public int triedQuestion;
    [HideInInspector] public int correctAnswer;
    [HideInInspector] public float performance;

    private void Awake() {
        //TODO: Don't destroy GameManager
        if(instance != null) return;

        instance = this;
        Load();
    }

    public void Save() {
        switch(question) {
            case QuestionType.Basic: PlayerPrefs.SetString("question", "basic"); break;
            case QuestionType.Normal: PlayerPrefs.SetString("question", "normal"); break;
            case QuestionType.Hard: PlayerPrefs.SetString("question", "hard"); break;
            case QuestionType.Expert: PlayerPrefs.SetString("question", "expert"); break;
            case QuestionType.LevelTest: PlayerPrefs.SetString("question", "test"); break;
        }

        PlayerPrefs.SetInt("questionCount", providedQuestionCount);
        PlayerPrefs.SetInt("triedQuestion", triedQuestion);
        PlayerPrefs.SetInt("correct", correctAnswer);
        PlayerPrefs.SetFloat("performance", performance);
    }

    public enum QuestionType {
         Basic, Normal, Hard, Expert, LevelTest
    }

    private void Load() {
        switch(PlayerPrefs.GetString("question")) {
            case "basic": question = QuestionType.Basic; break;
            case "normal": question = QuestionType.Normal; break;
            case "hard": question = QuestionType.Hard; break;
            case "expert": question = QuestionType.Expert; break;
            case "test": question = QuestionType.LevelTest; break;
        }

        int savedQuestionCount = PlayerPrefs.GetInt("questionCount");
        providedQuestionCount = savedQuestionCount == 0 ? 20 : savedQuestionCount;
        triedQuestion = PlayerPrefs.GetInt("triedQuestion");
        correctAnswer = PlayerPrefs.GetInt("correct");
        performance = PlayerPrefs.GetFloat("performance");
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("triedQuestion");
        PlayerPrefs.DeleteKey("correct");
        PlayerPrefs.DeleteKey("performance");

        providedQuestionCount = 20;
        triedQuestion = 0;
        correctAnswer = 0;
        performance = 0f;
    }
}
