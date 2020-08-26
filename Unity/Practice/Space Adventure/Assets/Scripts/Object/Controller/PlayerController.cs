using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    [SerializeField] private GameObject Laser;

    FirstPersonController FPSController;
    private Camera FPSCamera;

    private float SPandHPTimer;
    private float updatePressureInterval = 1f;
    private Coroutine pressureCoroutine;

    private void Start () {
        FPSController = gameObject.GetComponent<FirstPersonController>();
        FPSCamera = PlayerDB.instance.FPSCamera.GetComponent<Camera>();
        pressureCoroutine = StartCoroutine(PressureUpdater());
    }

    private IEnumerator PressureUpdater() {
        yield return new WaitForSeconds(updatePressureInterval);
        PlayerDB.pressure = Random.Range(0.9f, 1.1f);
        pressureCoroutine = StartCoroutine(PressureUpdater());
    }

    private void Update () {
        if (PlayerDB.CNTPlayerHP <= 0) {
            PlayerDB.pressure -= Time.deltaTime;
            Debug.Log("Game OVER");
        }

        //TODO: When damage function is available please delete below command. 
        if (Input.GetKeyDown(KeyCode.K)) {
            PlayerDB.CNTPlayerHP -= 5;
        } else if (Input.GetKeyDown(KeyCode.H)) {
            PlayerDB.CNTPlayerHP += 5;
        }

        WeaponTrigger();
        
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
            PlayerDB.isRunning = true;
        } else {
            PlayerDB.isRunning = false;
        }
    }

    private void FixedUpdate () {
        FPSControllerisState();
    }

    private void LateUpdate () {
        GetComponent<FirstPersonController>().enabled = !PlayerDB.isOnboard;
        PlayerStatus();
    }

    private void OnTriggerEnter (Collider col) {
        PlayerDB.whoIs = col.gameObject.tag;
        switch (col.gameObject.tag) {
            case "Helper":
                PlayerDB.communicationBool = true;
                break;
            case "Shuttle":
                PlayerDB.communicationBool = true;
                break;
            case "Weapon":
                PlayerDB.CNTPlayerHP -= BasicLaserController.ReturnDamage();
                break;
            default:
                PlayerDB.Unable = true;
                Debug.Log(gameObject.name + " collision by UNTAGGED object. (name: " + col.gameObject.name + ", tag: " + col.gameObject.tag + ")");
                break;
        }
    }

    private void OnTriggerStay (Collider col) {
        switch (col.gameObject.tag) {
            case "Helper":
                if (Input.GetMouseButton(0) && !PlayerDB.WeaponEnable) {
                    General.MessageShow = true;
                }
                break;
            case "Shuttle":
                if (Input.GetMouseButton(0) && !PlayerDB.WeaponEnable) {
                    General.MessageShow = true;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit (Collider col) {
        PlayerDB.whoIs = "";
        switch (col.gameObject.tag) {
            case "Helper":
                PlayerDB.communicationBool = false;
                break;
            case "Shuttle":
                PlayerDB.communicationBool = false;
                break;
            default:
                PlayerDB.Unable = false;
                break;
        }
    }

    private void FPSControllerisState () {
        FPSController.enabled = !General.MessageShow;
    }

    private void WeaponTrigger() {
        if(PlayerDB.WeaponEnable) {
            GetComponent<SphereCollider>().enabled = false;
            if(PlayerDB.cntSloat > 0) {
                RaycastHit hit;
                Ray ray = FPSCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, 1000f)) {
                    if(!hit.transform.CompareTag("Weapon")) {
                        Debug.Log(gameObject + " lock on by " + hit.transform.name + ". (tag: " + hit.transform.tag + ")");
                        General.Target = hit.transform.gameObject;
                    }
                } else {
                    General.Target = null;
                }
                if(Input.GetMouseButtonDown(0) && PlayerDB.cntSloat > 0) {
                    GameObject laser = Instantiate(Laser);
                    laser.transform.position = Camera.main.transform.position;
                    laser.transform.rotation = Camera.main.transform.rotation;
                    PlayerDB.cntSloat -= 1;
                    PlayerDB.havingSloat -= 1;
                } else if(Input.GetKeyDown(KeyCode.R) && PlayerDB.havingSloat < PlayerDB.maxSloat) {
                    if(PlayerDB.havingSloat < PlayerDB.sloatUnit) {
                        PlayerDB.cntSloat = PlayerDB.havingSloat;
                    } else {
                        PlayerDB.cntSloat = PlayerDB.sloatUnit;
                    }
                }
            } else {
                PlayerDB.Reload = true;
                if(Input.GetKeyDown(KeyCode.R) && PlayerDB.havingSloat < PlayerDB.maxSloat) {
                    if(PlayerDB.havingSloat < PlayerDB.sloatUnit) {
                        PlayerDB.cntSloat = PlayerDB.havingSloat;
                    } else {
                        PlayerDB.cntSloat = PlayerDB.sloatUnit;
                    }
                    PlayerDB.Reload = false;
                }
            }
        } else {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void PlayerStatus() {
        if(PlayerDB.playerSP != PlayerDB.CNTPlayerSP) {
            SPandHPTimer = Time.deltaTime + SPandHPTimer;
        }

        if(Input.GetKeyUp(KeyCode.Return)) {
            if(PlayerDB.CNTPlayerSP >= 1) {
                PlayerDB.CNTPlayerSP -= 1;
            } else {
                if(PlayerDB.CNTPlayerHP >= 22) {
                    PlayerDB.CNTPlayerHP -= 2;
                }
            }
            SPandHPTimer = 0;
        } else if(Input.GetKeyUp(KeyCode.Space) && !General.MessageShow) {
            if(PlayerDB.CNTPlayerSP >= 2) {
                PlayerDB.CNTPlayerSP -= 2;
            } else {
                if(PlayerDB.CNTPlayerHP >= 23) {
                    PlayerDB.CNTPlayerHP -= 3;
                }
            }
            SPandHPTimer = 0;
        } else if(PlayerDB.isRunning) {
            if(PlayerDB.CNTPlayerSP >= 3) {
                PlayerDB.CNTPlayerSP -= 3;
            } else {
                if(PlayerDB.CNTPlayerHP >= 25) {
                    PlayerDB.CNTPlayerHP -= 5;
                }
            }
            SPandHPTimer = 0;
        } else if(SPandHPTimer > 30f) {
            if(PlayerDB.CNTPlayerSP < PlayerDB.playerSP + 10) {
                PlayerDB.CNTPlayerSP += 10;
                if(PlayerDB.CNTPlayerSP > PlayerDB.playerSP) {
                    PlayerDB.CNTPlayerSP = PlayerDB.playerSP;
                } 
            }
            if(PlayerDB.CNTPlayerHP < PlayerDB.playerHP - 5) {
                PlayerDB.CNTPlayerHP += 5;
            }
            SPandHPTimer = 0;
        }
    }
}
