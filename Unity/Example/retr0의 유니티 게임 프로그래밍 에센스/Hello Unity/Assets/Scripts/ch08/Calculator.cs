using UnityEngine;

public class Calculator : MonoBehaviour {
    private delegate float Calculate(float a, float b);
    private Calculate onCalculate;

    private float Sum(float a, float b) {
        Debug.Log(a + b);
        return a + b;
    }

    private float Sub(float a, float b) {
        Debug.Log(a - b);
        return a - b;
    }
    
    private float Mul(float a, float b) {
        Debug.Log(a * b);
        return a * b;
    }

    private void Start() {
        onCalculate = Sum;
        onCalculate += Sub;
        onCalculate -= Sub;
        onCalculate += Mul;
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.LogFormat("결과값: {0}", onCalculate(1, 10));
        }
    }
}
