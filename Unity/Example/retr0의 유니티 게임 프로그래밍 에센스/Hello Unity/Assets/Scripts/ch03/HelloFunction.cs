using UnityEngine;

public class HelloFunction : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        float circle = 30f, radius = GetRadius(circle);
        Debug.LogFormat("원의 사이즈: {0}, 원의 반지름: {1}", circle, radius);
    }

    //Scope
    private float GetRadius(float size) {
        const float pi = 3.141592f;
        float temp = size / pi;
        return Mathf.Sqrt(temp);
    }
}
