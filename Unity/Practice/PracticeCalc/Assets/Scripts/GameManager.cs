using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [HideInInspector] public QuestionType question;
    [HideInInspector] public int triedQuestion;
    [HideInInspector] public int correctAnswer;
    [HideInInspector] public float performance;

    [HideInInspector] public int providedQuestionCount;
    [HideInInspector] public bool modCalc;
    [HideInInspector] public ManagerType manageOption;

    private void Awake() {
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

        switch(manageOption) {
            case ManagerType.Disable: PlayerPrefs.SetInt("manager", 0); break;
            case ManagerType.Host: PlayerPrefs.SetInt("manager", 1); break;
            case ManagerType.Client: PlayerPrefs.SetInt("manager", 2); break;
        }

        PlayerPrefs.SetInt("questionCount", providedQuestionCount);
        PlayerPrefs.SetInt("triedQuestion", triedQuestion);
        PlayerPrefs.SetInt("correct", correctAnswer);
        PlayerPrefs.SetFloat("performance", performance);
        PlayerPrefs.SetInt("modCalc", modCalc ? 1 : 0);
    }

    public enum QuestionType {
         Basic, Normal, Hard, Expert, LevelTest
    }

    public enum ManagerType {
        Disable, Host, Client
    }

    private void Load() {
        switch(PlayerPrefs.GetString("question")) {
            case "basic": question = QuestionType.Basic; break;
            case "normal": question = QuestionType.Normal; break;
            case "hard": question = QuestionType.Hard; break;
            case "expert": question = QuestionType.Expert; break;
            case "test": question = QuestionType.LevelTest; break;
        }

        switch(PlayerPrefs.GetInt("manager")) {
            case 0: manageOption = ManagerType.Disable; break;
            case 1: manageOption = ManagerType.Host; break;
            case 2: manageOption = ManagerType.Client; break;
        }

        int savedQuestionCount = PlayerPrefs.GetInt("questionCount");
        providedQuestionCount = savedQuestionCount == 0 ? 20 : savedQuestionCount;
        triedQuestion = PlayerPrefs.GetInt("triedQuestion");
        correctAnswer = PlayerPrefs.GetInt("correct");
        performance = PlayerPrefs.GetFloat("performance");
        modCalc = PlayerPrefs.GetInt("modCalc") == 1;
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("triedQuestion");
        PlayerPrefs.DeleteKey("correct");
        PlayerPrefs.DeleteKey("performance");

        triedQuestion = 0;
        correctAnswer = 0;
        performance = 0f;
    }

    public void ResetSetting() {
        PlayerPrefs.DeleteKey("questionCount");
        PlayerPrefs.DeleteKey("modCalc");
        PlayerPrefs.DeleteKey("manager");

        providedQuestionCount = 20;
        modCalc = false;
        manageOption = ManagerType.Disable;
    }
}
