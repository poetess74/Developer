using UnityEngine;
using UnityEngine.UI;

public class CircleProgressController : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private Text progressText;

    // 일부값 ÷ 전체값 X 100
    public void setProgressValue(float value, float maxValue, Color tintColor) {
        background.color = tintColor;
        background.fillAmount = value / maxValue;
        progressText.text = (int)(value / maxValue * 100) + "%";
    }

    public void disableProgress() {
        background.fillAmount = 0;
        progressText.text = "0%";
        gameObject.SetActive(false);
    }
}