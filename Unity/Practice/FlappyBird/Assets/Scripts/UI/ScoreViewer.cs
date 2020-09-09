using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private Image digit;
    [SerializeField] private Camera mainCamera;

    private Vector3 digitWorldPoint;

    private void Start() {
        digitWorldPoint = mainCamera.ScreenToWorldPoint(digit.transform.position);
        Debug.Log("target height:" + digitWorldPoint.y);
    }

    private void Update() {
        if(Mathf.Approximately(player.transform.position.y, digitWorldPoint.y)) {
            digit.color = new Color(1f, 1f, 1f, 0.5f);
        } else {
            digit.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
