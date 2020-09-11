using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    [SerializeField] private List<Number> controlPans;
    [SerializeField] private char digitSize;
    [SerializeField] private GameObject newRecord;
    private void Update() {
        controlPans[0].Set((int) GamePlayManager.Score, digitSize, true);
        if(controlPans.Count - 1 != 1) return;
        controlPans[1].Set((int) GamePlayManager.bestScore, digitSize, true);
        newRecord.SetActive(GamePlayManager.isBestScore);
    }
}
