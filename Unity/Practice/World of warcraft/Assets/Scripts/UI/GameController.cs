using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject charInfo;
    [SerializeField] private GameObject login;
    [SerializeField] private GameObject logout;
    [SerializeField] private GameObject createChar;
    [SerializeField] private GameObject avatar;
    [SerializeField] private GameObject loadButton;

    private void Update() {
        if (loadButton == null) return;
        loadButton.SetActive(GamePlayManager.PlayerName != null && GamePlayManager.PlayerLV != 0);
    }
    
    private void StartNewGame() {
        login.SetActive(false);
        createChar.SetActive(true);
    }

    private void LoadGame() {
        login.SetActive(false);
        SetAvatar(true);
    }

    private void LaunchGame() {
        SceneManager.LoadScene("Field");
    }
    
    private void LogoutGame() {
        SceneManager.LoadScene("Intro");
    }

    private void Setting() { }

    private void CreateChar() {
        createChar.SetActive(false); 
        SetAvatar(true);
    }
    
    private void Logout() {
        login.SetActive(true);
        SetAvatar(false);
    }

    private void OnApplicationExit() {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void SetAvatar(bool trigger) {
        charInfo.SetActive(trigger);
        logout.SetActive(trigger);
        GameObject body = avatar.transform.GetChild(0).gameObject;
        body.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        avatar.SetActive(trigger);
    }
}
