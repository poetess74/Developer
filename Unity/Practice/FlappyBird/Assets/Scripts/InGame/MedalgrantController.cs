using UnityEngine;

public class MedalgrantController : MonoBehaviour {
    [SerializeField] private GameObject goldMedal;
    [SerializeField] private GameObject silverMedal;
    private void Update() {
        if(GamePlayManager.Score >= 5 && GamePlayManager.Score <= 9 && GamePlayManager.isBestScore) {
            silverMedal.SetActive(true);
        } else if(GamePlayManager.Score >= 10 && GamePlayManager.isBestScore) {
            goldMedal.SetActive(true);
        } else {
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
        }
    }
}
