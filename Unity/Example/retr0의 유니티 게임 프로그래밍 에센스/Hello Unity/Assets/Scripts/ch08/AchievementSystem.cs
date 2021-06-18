using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour {
    private Text achievementText;

    private void Start() {
        achievementText = GameObject.Find("Achievement").GetComponent<Text>();
    }

    public void UnlockAchievement(string title) {
        Debug.LogFormat("도전과제 해제! - {0}", title);
        achievementText.text = $"도전과제 해제: {title}";
    }
}
