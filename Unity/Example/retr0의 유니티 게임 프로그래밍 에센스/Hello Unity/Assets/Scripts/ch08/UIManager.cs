using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private Text playerStatus;

    private void Start() {
        playerStatus = GameObject.Find("PlayerStatus").GetComponent<Text>();
    }

    public void OnPlayerDead() {
        playerStatus.text = "You Died!";
    }
}
