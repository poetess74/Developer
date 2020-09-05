using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private Image digit;
    private void Update() {
        if(player.transform.position.y > 3 && player.transform.position.y < 4) {
            digit.color = new Color(1f, 1f, 1f, 0.5f);
        } else {
            digit.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
