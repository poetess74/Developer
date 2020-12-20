using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class WarningController : MonoBehaviour {
    [SerializeField] private Text message;
    [SerializeField] private GameObject avatar;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip lostConnection;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        if(GamePlayManager.PlayerLV == 0) {
            message.gameObject.SetActive(true);
            avatar.GetComponent<ThirdPersonUserControl>().enabled = false;
            message.text = "서버와 연결이 끊어졌습니다. ";
            audioSource.clip = lostConnection;
            audioSource.Play();
        }
    }
}
