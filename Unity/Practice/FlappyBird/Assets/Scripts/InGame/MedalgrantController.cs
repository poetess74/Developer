using UnityEngine;

public class MedalgrantController : MonoBehaviour {
    [SerializeField] private GameObject goldMedal;
    [SerializeField] private GameObject silverMedal;

    private bool trigger;
    private void Update() {
        if(GamePlayManager.Score >= 5 && GamePlayManager.Score <= 9 && GamePlayManager.isBestScore) {
            if(trigger) return;
            silverMedal.SetActive(true);
            GamePlayManager.Score += 1;
            GamePlayManager.bestScore += 1;
            trigger = true;
        } else if(GamePlayManager.Score >= 10 && GamePlayManager.isBestScore) {
            if(silverMedal.activeSelf && trigger) {
                trigger = false;
                silverMedal.SetActive(!silverMedal.activeSelf);
            } else if(!trigger) {
                GamePlayManager.Score += 2;
                GamePlayManager.bestScore += 2;
            }
            if(trigger) return;
            goldMedal.SetActive(true);
            trigger = true;
        } else {
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
        }
    }
}
