using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private Image digit;
    [SerializeField] private Camera mainCamera;

    private Vector3 digitWorldPoint;

    private void Start() {
        digitWorldPoint = mainCamera.ScreenToWorldPoint(digit.transform.position);
    }

    private void Update() {
        digit.color = 
            (int)Mathf.Round(player.transform.position.y) == (int)Mathf.Round(digitWorldPoint.y) ? 
            new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 1f, 1f, 1f);
    }
}
