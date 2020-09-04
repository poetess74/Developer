using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {
    [SerializeField] private GameObject digitPrintLocation;
    
    [SerializeField] private List<Sprite> smallDigit;
    [SerializeField] private List<Sprite> midDigit;
    [SerializeField] private List<Sprite> bigDigit;

    [SerializeField] private List<GameObject> digits;
    private void Start() {
        if(digits == null) {
            digits = new List<GameObject>();
        } 
    }

    private void Update() {
        
    }
}
