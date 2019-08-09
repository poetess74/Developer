using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public static PlayerUI Instance;

    public GameObject DefaultPointer;
    public GameObject AttectPointer;

    public Text Name;
    public Text Pressure;
    public Slider HP;
    public Slider SP;

    public Text WeaponName;
    public Text CntSloat;
    public Text AllSloat;
    public Slider CntSloatProgress;
    public Slider AllSloatProgress;

    public Animation messageAnim;
    public Animation weaponAnim;

    public GameObject warnO2;
    public GameObject warnCO2;
    public GameObject warnPressure;
    public GameObject warnSystem;

    public Text warnO2Reason;
    public Text warnO2Pressure;
    public Text warnCO2Pressure;
    public Text warnPressureReason;
    public Text warningPressure;

    public Text warnSystemFailureTitle;
    public Text warnSystemFailureMsg;

    public GameObject WeaponHUD;

    public GameObject Communication;
    public Text ComunicationText;
    public GameObject Unable;
    public GameObject Lock;

    public GameObject Reload;
    public GameObject UnableLanuch;

    public GameObject MessageBox;
    public Text MessageTitle;
    public Text MessageText;

    public void Awake () {
        Instance = this;
    }

    private bool weaponHUDOn;

    private float SPandHPTimer;

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (weaponHUDOn) {
                WeaponHUDOff();
            } else {
                WeaponHUDOn();
            }
            weaponHUDOn = !weaponHUDOn;
            GamePlayManager.WeaponEnable = !GamePlayManager.WeaponEnable;
        }
    }

    private void LateUpdate () {
        SPandHPController();
    }

    private void FixedUpdate () {
        Communications();
        Unables();
        Locks();
        ReloadNow();
        UnableLaunches();
        ShowMessageBox();
    }

    public void Communications () {
        this.Communication.SetActive(GamePlayManager.communicationBool);
        if (GamePlayManager.communicationBool) {
            this.ComunicationText.text = GamePlayManager.whoIs;
        }
    }

    public void Unables () {
        this.Unable.SetActive(GamePlayManager.Unable);
    }

    public void Locks () {
        this.Lock.SetActive(GamePlayManager.Lock);
    }


    public void ReloadNow () {
        this.Reload.SetActive(GamePlayManager.Reload);
    }

    public void UnableLaunches () {
        this.UnableLanuch.SetActive(GamePlayManager.UnableLaunch);
    }

    public void ShowMessageBox () {
        if (GamePlayManager.MessageShow) {
            MessageBox.SetActive(GamePlayManager.MessageShow);
            MessageTitle.text = GamePlayManager.MessageTitle;
            MessageText.text = GamePlayManager.MessageText;
            if (Input.GetKeyUp(KeyCode.Space)) {
                GamePlayManager.NextMessage = true;
            }
        } else {
            MessageBox.SetActive(GamePlayManager.MessageShow);
        }
    }

    public void TurnOffAllWarns () {
        warnO2.SetActive(false);
        warnCO2.SetActive(false);
        warnPressure.SetActive(false);
        warnSystem.SetActive(false);
    }

    public void WarnO2 () {
        TurnOffAllWarns();
        warnO2.SetActive(true);
        messageAnim.Play();
    }

    public void WarnCO2 () {
        TurnOffAllWarns();
        warnCO2.SetActive(true);
        messageAnim.Play();
    }

    public void WarnPressure () {
        TurnOffAllWarns();
        warnPressure.SetActive(true);
        messageAnim.Play();
    }

    public void WarnSytem () {
        TurnOffAllWarns();
        warnSystem.SetActive(true);
        messageAnim.Play();
    }

    public void WeaponHUDOn () {
        AttectPointer.SetActive(true);
        weaponAnim.Play("WeaponActive");
        DefaultPointer.SetActive(false);
    }

    public void WeaponHUDOff () {
        DefaultPointer.SetActive(true);
        weaponAnim.Play("WeaponTerminate");
        AttectPointer.SetActive(false);
    }

    private void SPandHPController () {
        if (GamePlayManager.playerSP != GamePlayManager.CNTPlayerSP) {
            SPandHPTimer = Time.deltaTime + SPandHPTimer;
        }

        if (Input.GetKeyUp(KeyCode.Return)) {
            if (GamePlayManager.CNTPlayerHP > 1) {
                GamePlayManager.CNTPlayerHP -= 1;
                HP.value = GamePlayManager.CNTPlayerHP;
            }
            SPandHPTimer = 0;
        } else if (Input.GetKeyUp(KeyCode.Space) && !GamePlayManager.MessageShow) {
            if (GamePlayManager.CNTPlayerSP > 1) {
                GamePlayManager.CNTPlayerSP -= 1;
                SP.value = GamePlayManager.CNTPlayerSP;
            } else {
                if (GamePlayManager.CNTPlayerHP > 2) {
                    GamePlayManager.CNTPlayerHP -= 2;
                    HP.value = GamePlayManager.CNTPlayerHP;
                }
            }
            SPandHPTimer = 0;
        } else if (GamePlayManager.isRunning) {
            if (GamePlayManager.CNTPlayerSP > 3) {
                GamePlayManager.CNTPlayerSP -= 3 + (int)Time.deltaTime;
                SP.value = GamePlayManager.CNTPlayerSP;
            } else {
                if (GamePlayManager.CNTPlayerHP > 5) {
                    GamePlayManager.CNTPlayerHP -= 5 + (int)Time.deltaTime;
                    HP.value = GamePlayManager.CNTPlayerHP;
                }
            }
            SPandHPTimer = 0;
        } else if (SPandHPTimer > 30f) {
            if (GamePlayManager.CNTPlayerSP < GamePlayManager.playerSP + 10) {
                GamePlayManager.CNTPlayerSP += 10;
                if (GamePlayManager.CNTPlayerSP > GamePlayManager.playerSP) {
                    GamePlayManager.CNTPlayerSP = GamePlayManager.playerSP;
                } else {
                    SP.value = GamePlayManager.CNTPlayerSP;
                }
            }
            if (GamePlayManager.CNTPlayerHP < GamePlayManager.playerHP - 5) {
                GamePlayManager.CNTPlayerHP += 5;
                HP.value = GamePlayManager.CNTPlayerHP;
            }
            SPandHPTimer = 0;
        }
    }
}
