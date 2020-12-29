using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour {
    private Image progress;
    public static ProgressController progressController;

    private bool running;
    private float processTime;
    private string name;

    private void Start() {
        progress = GetComponent<Image>();
        name = gameObject.name.Substring(2);
    }

    private void Awake() {
        progressController = this;
    }

    public void progressInitializer(float specifiedTime) {
        if(running) {
            Debug.LogWarning("Warning: skill progress already running! Last data has been ignored.");
            return;
        }
        processTime = specifiedTime;
        progressRunner();
    }

    private void progressRunner() {
        StartCoroutine(skillCastingTimer(processTime));
    }
    

    private IEnumerator skillCastingTimer(float specifiedTime) {
        running = true;
        float elapsedTime = 0f;
        while(specifiedTime > elapsedTime) {
            setProgressValue(elapsedTime, specifiedTime);
            yield return new WaitForSeconds(0.01f);
            elapsedTime += 0.01f;
        }
        running = false;
    }

    public void resetProgress() {
        StopCoroutine(skillCastingTimer(processTime));
        progress.fillAmount = 0;
        processTime = 0f;
        running = false;
    }
    
    private void setProgressValue(float value, float maxValue) {
        progress.color = new Color(0f, 0f, 0f, 0.5f);
        progress.fillAmount = 1 - value / maxValue;
    }
}