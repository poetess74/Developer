using UnityEngine;

public class ColorChange : MonoBehaviour {
    public void ChangeColor() {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
    
    public void ChangeColor(bool isOn) {
        GetComponent<Renderer>().material.color = isOn ? Random.ColorHSV() : Color.white;
    }
    
    public void ChangeColor(float percentage) {
        Color color = new Color(percentage, 0, 0);
        GetComponent<Renderer>().material.color = color;
    }
}
