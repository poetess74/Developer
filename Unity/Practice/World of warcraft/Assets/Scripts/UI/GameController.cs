using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject charInfo;
    [SerializeField] private GameObject login;
    [SerializeField] private GameObject logout;
    [SerializeField] private GameObject createChar;
    [SerializeField] private GameObject avatar;
    
    private void StartNewGame() {
        login.SetActive(false);
        createChar.SetActive(true);
    }

    private void LoadGame() {
        login.SetActive(false);
        SetAvatar(true);
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
        avatar.SetActive(trigger);
    }
}
