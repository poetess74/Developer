using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class WarningController : MonoBehaviour {
    [SerializeField] private Text message;
    [SerializeField] private AnimationClip messageAnimClip;
    [SerializeField] private GameObject avatar;
    [SerializeField] private AudioClip lostConnection;

    public static WarningController warningController;
    private Animation messageAnim;
    private AudioSource audioSource;

    private void Awake() {
        warningController = this;
        messageAnim = GetComponentInChildren<Animation>(true);
        messageAnim.clip = messageAnimClip;
    }
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        if(GamePlayManager.PlayerLV == 0) {
            avatar.GetComponent<ThirdPersonUserControl>().enabled = false;
            ShowMessage("서버와 연결이 끊어졌습니다. ", lostConnection);
        }
    }

    private void Update() {
        message.gameObject.SetActive(audioSource.isPlaying);
    }

    public void ShowMessage(string input, AudioClip sound) {
        message.text = input;
        messageAnim.Rewind();
        messageAnim.Play();
        audioSource.clip = sound;
        audioSource.Play();
    }
}
