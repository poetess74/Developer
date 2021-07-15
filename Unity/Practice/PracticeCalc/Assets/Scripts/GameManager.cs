using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [HideInInspector] public QuestionType question;

    [HideInInspector] public int triedQuestion;
    [HideInInspector] public int correctAnswer;
    [HideInInspector] public float performance;

    private void Awake() {
        //TODO: Don't destroy GameManager
        if(instance != null) return;

        instance = this;
        Reset();
    }

    public enum QuestionType {
         Basic, Normal, Hard, Expert, LevelTest
    }

    public void Reset() {
        triedQuestion = 0;
        correctAnswer = 0;
        performance = 0f;
    }
}
