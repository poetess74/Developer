using UnityEngine;

public class Calc : MonoBehaviour {
    void Start() {
        Debug.Log(Sum(1, 1));
        Debug.Log(Sum(-5, 8, 10));
        
        Debug.Log(Sum(1.3f, 1.6f));
        Debug.Log(Sum(3.14f, 3.14f, 3.14f));
    }
    
    private int Sum(int inputA, int inputB) {
        return inputA + inputB;
    }
    
    private int Sum(int inputA, int inputB, int inputC) {
        return inputA + inputB + inputC;
    }

    private float Sum(float inputA, float inputB) {
        return inputA + inputB;
    }
    
    private float Sum(float inputA, float inputB, float inputC) {
        return inputA + inputB + inputC;
    }
}
