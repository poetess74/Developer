using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    [SerializeField] private List<Number> controlPans;
    private int count = 0;
    private void Start() {
        
    }

    private void Update() {
        count += Random.Range(0, 10);
        foreach(var number in controlPans) {
            number.Set((int)GamePlayManager.score, 'S');
        }
    }
}
