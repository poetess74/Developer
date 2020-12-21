using UnityEngine;
using UnityEngine.UI;

public class CircleProgressController : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private Text progressText;
    
    public static CircleProgressController circleProgressController;

    private void Awake() {
        circleProgressController = this;
    }

    // 일부값 ÷ 전체값 X 100
    public void setProgressValue(float value, float maxValue) {
        background.fillAmount = value / maxValue;
        progressText.text = (int)(value / maxValue * 100) + "%";
    }

    public void removeProgress() {
        Destroy(gameObject);
    }
}