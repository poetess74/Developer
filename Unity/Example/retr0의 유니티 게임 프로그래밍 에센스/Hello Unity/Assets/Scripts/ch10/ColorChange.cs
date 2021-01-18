using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {
    [SerializeField] private Toggle toggle;

    private void Start() {
        Debug.Log(toggle.isOn);
    }
    
    public void ChangeColor() {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
    
    public void ChangeColor(bool isOn) {
        GetComponent<Renderer>().material.color = isOn ? Random.ColorHSV() : Color.white;
    }
}
