using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour {
    [SerializeField] private Slider slider;
    
    // Start is called before the first frame update
    private void Start() {
        slider.value = 0.5f;
    }
}
