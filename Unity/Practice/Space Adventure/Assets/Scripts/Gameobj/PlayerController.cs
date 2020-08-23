using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    [SerializeField] private GameObject Laser;

    FirstPersonController FPSController;

    private void Start () {
        FPSController = gameObject.GetComponent<FirstPersonController>();
    }

    private void Update () {
        if (GamePlayManager.WeaponEnable) {
            if (GamePlayManager.cntSloat > 0) {
                if (Input.GetMouseButtonDown(0) && !GamePlayManager.UnableLaunch && GamePlayManager.cntSloat > 0) {
                    GameObject laser = Instantiate(Laser, this.transform);
                    laser.transform.position = Camera.main.transform.position;
                    laser.transform.rotation = Camera.main.transform.rotation;
                    GamePlayManager.cntSloat -= 1;
                    GamePlayManager.havingSloat -= 1;
                } else if (Input.GetKeyDown(KeyCode.R) && GamePlayManager.havingSloat < GamePlayManager.maxSloat) {
                    if (GamePlayManager.havingSloat < GamePlayManager.sloatUnit) {
                        GamePlayManager.cntSloat = GamePlayManager.havingSloat;
                    } else {
                        GamePlayManager.cntSloat = GamePlayManager.sloatUnit;
                    }
                }
            } else {
                GamePlayManager.Reload = true;
                if (Input.GetKeyDown(KeyCode.R) && GamePlayManager.havingSloat < GamePlayManager.maxSloat) {
                    if (GamePlayManager.havingSloat < GamePlayManager.sloatUnit) {
                        GamePlayManager.cntSloat = GamePlayManager.havingSloat;
                    } else {
                        GamePlayManager.cntSloat = GamePlayManager.sloatUnit;
                    }
                    GamePlayManager.Reload = false;
                }
            }
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
            GamePlayManager.isRunning = true;
        } else {
            GamePlayManager.isRunning = false;
        }
    }

    private void FixedUpdate () {
        FPSControllerisState();
    }

    private void LateUpdate () {
        GetComponent<FirstPersonController>().enabled = !GamePlayManager.isOnboard;
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
                Debug.Log("UNLINKED Fix this object (tag: " + col.gameObject.tag + ", name: " + col.gameObject.name + ")");
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
