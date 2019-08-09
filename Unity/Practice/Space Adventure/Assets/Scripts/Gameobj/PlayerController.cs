using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Laser;

    UnityStandardAssets.Characters.FirstPerson.FirstPersonController FPSController;

    private void Start () {
        FPSController = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    private void Update () {
        if (GamePlayManager.WeaponEnable) {
            if (GamePlayManager.cntSloat <= GamePlayManager.allSloat) {
                if (Input.GetMouseButtonDown(0)) {
                    if (!GamePlayManager.UnableLaunch || GamePlayManager.cntSloat == 0) {
                        GameObject laser = Instantiate(Laser, this.transform);
                        laser.transform.position = Camera.main.transform.position;
                        laser.transform.rotation = Camera.main.transform.rotation;
                        GamePlayManager.cntSloat -= 1;
                    }
                }
            } else {
                GamePlayManager.Reload = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            GamePlayManager.isRunning = true;
        } else {
            GamePlayManager.isRunning = false;
        }
    }

    private void FixedUpdate () {
        FPSControllerisState();
    }

    private void OnTriggerEnter (Collider col) {
        GamePlayManager.whoIs = col.gameObject.tag;
        switch (col.gameObject.tag) {
            case "Helper":
                GamePlayManager.communicationBool = true;
                GamePlayManager.UnableLaunch = true;
                break;
            case "Shuttle":
                GamePlayManager.communicationBool = true;
                GamePlayManager.UnableLaunch = true;
                break;
            case "Ground":
                GamePlayManager.UnableLaunch = true;
                break;
            default:
                GamePlayManager.Unable = true;
                Debug.Log(col.gameObject.name + " / " + col.gameObject.tag);
                break;
        }
    }

    private void OnTriggerStay (Collider col) {
        switch (col.gameObject.tag) {
            case "Helper":
                if (Input.GetMouseButton(0) && !GamePlayManager.WeaponEnable) {
                    GamePlayManager.MessageShow = true;
                }
                break;
            case "Shuttle":
                if (Input.GetMouseButton(0) && !GamePlayManager.WeaponEnable) {
                    GamePlayManager.MessageShow = true;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit (Collider col) {
        GamePlayManager.whoIs = "";
        switch (col.gameObject.tag) {
            case "Helper":
                GamePlayManager.communicationBool = false;
                GamePlayManager.UnableLaunch = false;
                break;
            case "Shuttle":
                GamePlayManager.communicationBool = false;
                GamePlayManager.UnableLaunch = false;
                break;
            case "Ground":
                GamePlayManager.UnableLaunch = false;
                break;
            default:
                GamePlayManager.Unable = false;
                break;
        }
    }

    private void FPSControllerisState () {
        FPSController.enabled = !GamePlayManager.MessageShow;
    }
}
