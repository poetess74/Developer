using System;
using UnityEngine;

public class Worker : MonoBehaviour {
    private Action work;

    private void MoveBricks() {
        Debug.Log("벽돌을 옮겼다. ");
    }
    
    private void DigIn() {
        Debug.Log("땅을 팠다. ");
    }
    
    // Start is called before the first frame update
    private void Start() {
        work += MoveBricks;
        work += DigIn;
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            work();
        }
    }
}
