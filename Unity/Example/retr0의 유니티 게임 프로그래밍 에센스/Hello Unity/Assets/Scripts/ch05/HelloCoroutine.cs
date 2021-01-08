using System.Collections;
using UnityEngine;

public class HelloCoroutine : MonoBehaviour {
    private void Start() {
        StartCoroutine("HelloUnity");
    }

    private void Update() {
        if(!Input.GetMouseButtonDown(0)) return;
        StopCoroutine("HelloUnity");
    }
    
    private IEnumerator HelloUnity() {
        while(true) {
            yield return new WaitForSeconds(3f);
            Debug.Log("Hello Unity");
        }
    }
}
