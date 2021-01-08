using System.Collections.Generic;
using UnityEngine;

public class HelloList : MonoBehaviour {
    [SerializeField] private List<int> scores = new List<int>();

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if(scores.Count > 0) return;
            for(int i = 0; i < 16; i++) {
                scores.Add((int)Mathf.Pow(2, i));
            }
        } else if(Input.GetMouseButtonDown(1)) {
            scores.Clear();
        }
    }
}
