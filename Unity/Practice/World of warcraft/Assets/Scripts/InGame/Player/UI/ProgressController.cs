using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {
    private Image progress;
    public static ProgressController progressController;

    private float castingTime, cooldownTime, cost;
    private int skillKey, skillKeyCode;

    private void Start() {
        progress = GetComponent<Image>();
    }

    private void Awake() {
        progressController = this;
    }

    public void progressInitializer(float castingTime, float cooldownTime, float cost, int skillKey, int skillKeyCode) {
        this.castingTime = castingTime;
        this.cooldownTime = cooldownTime;
        this.cost = cost;
        this.skillKey = skillKey;
        this.skillKeyCode = skillKeyCode;
    }
    
    [Obsolete]
    public void setProgressValue(float value, float maxValue) {
        progress.color = new Color(0f, 0f, 0f, 0.5f);
        progress.fillAmount = 1 - value / maxValue;
    }

    [Obsolete]
    public void disableProgress() {
        progress.fillAmount = 0;
        gameObject.SetActive(false);
    }
}