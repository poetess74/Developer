using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {
    private Image progress;

    private void Start() {
        progress = GetComponent<Image>();
    }
    
    public void setProgressValue(float value, float maxValue) {
        progress.color = new Color(0f, 0f, 0f, 0.5f);
        progress.fillAmount = 1 - value / maxValue;
    }

    public void disableProgress() {
        progress.fillAmount = 0;
        gameObject.SetActive(false);
    }
}