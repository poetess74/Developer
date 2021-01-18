using UnityEngine;

public class ColorChange : MonoBehaviour {
    public void ChangeColor() {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
