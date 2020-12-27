using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {
    private Image progress;

    private void Start() {
        progress = GetComponent<Image>();
    }
    
    public void setProgressValue(float value, float maxValue, Color tintColor) {
        progress.color = tintColor;
        progress.fillAmount = 1 - value / maxValue;
    }

    public void disableProgress() {
        progress.fillAmount = 0;
        gameObject.SetActive(false);
    }
}