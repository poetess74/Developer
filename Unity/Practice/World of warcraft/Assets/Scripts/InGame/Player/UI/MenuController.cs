using UnityEngine;

public class MenuController : MonoBehaviour {
    [SerializeField] private GameObject menuBox;
    [SerializeField] private AudioClip menuOpen;
    [SerializeField] private AudioClip menuClose;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void MenuOpen() {
        audioSource.clip = menuBox.activeSelf ? menuClose : menuOpen;
        audioSource.Play();
        menuBox.SetActive(!menuBox.activeSelf);
    }

    private void Info() {
        menuBox.SetActive(false);
    }

    private void Setting() {
        menuBox.SetActive(false);
    }
}
