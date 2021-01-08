using UnityEngine;

public class HelloMath : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        /*
        int a = 5, b = 7, sum = a + b;
        Debug.Log(sum);
        sum = a - b;
        Debug.Log(sum);
        Debug.Log(a * b);
        Debug.Log(a / b);
        Debug.Log(b / a);
        Debug.Log(a % b);
        Debug.Log(b % a);
        */
        int i = 0, j = 10;
        Debug.Log(i++);
        Debug.Log(i);
        Debug.Log(--i);
        Debug.Log(i);

        j += 5;
        Debug.Log(j);
        j -= 5;
        Debug.Log(j);
        j *= 5;
        Debug.Log(j);
        j /= 5;
        Debug.Log(j);
        j %= 5;
        Debug.Log(j);
    }
}
