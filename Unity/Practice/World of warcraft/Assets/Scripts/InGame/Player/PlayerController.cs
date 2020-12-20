using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject menuBox;
    [SerializeField] private AudioClip menuOpen;
    [SerializeField] private AudioClip menuClose;
    [SerializeField] private AudioClip noTarget;
    
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            audioSource.clip = menuBox.activeSelf ? menuClose : menuOpen;
            audioSource.Play();
            menuBox.SetActive(!menuBox.activeSelf);
        }
        if (GamePlayManager.PlayerLV == 0) return;
        if(Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Quest");
        } else if(Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Equip");
        } else if(Input.GetKeyDown(KeyCode.I)) {
            Debug.Log("Item");
        } else if(Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("Skill");
        } else if(Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Map");
        } else if(Input.GetKeyDown(KeyCode.Alpha1) && GamePlayManager.PlayerLV >= 1) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha2) && GamePlayManager.PlayerLV >= 1) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha3) && GamePlayManager.PlayerLV >= 2) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha4) && GamePlayManager.PlayerLV >= 2) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha5) && GamePlayManager.PlayerLV >= 3) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha6) && GamePlayManager.PlayerLV >= 3) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha7) && GamePlayManager.PlayerLV >= 4) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha8) && GamePlayManager.PlayerLV >= 4) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha9) && GamePlayManager.PlayerLV >= 5) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha0) && GamePlayManager.PlayerLV >= 5) {
            if(GamePlayManager.TargetLV == 0) {
                WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            }
        }
    }
}
