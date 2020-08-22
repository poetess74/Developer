using System.Collections;
using System.Collections.Generic;
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
    public Animation reloadAnim;

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

    public float updatePressureInterval = 1f;
    private bool latestReloadStatus;
    private Coroutine pressureCoroutine;
    
    public void Awake () {
        Instance = this;
    }

    private bool weaponHUDOn;

    private float SPandHPTimer;

    private void Start () {
        pressureCoroutine = StartCoroutine(PressureUpdater());
    }

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
        // TODO: Make fatal decompression code.
    }

    private void LateUpdate () {
        StatusController();
        SyncMaxUnit();
    }

    private void FixedUpdate () {
        Communications();
        Unables();
        Locks();
        UnableLaunches();
        ShowMessageBox();
    }

    private void SyncMaxUnit () {
        CntSloatProgress.maxValue = GamePlayManager.sloatUnit;
        AllSloatProgress.maxValue = GamePlayManager.maxSloat;
        HP.maxValue = GamePlayManager.playerHP;
        SP.maxValue = GamePlayManager.playerSP;
    }

    IEnumerator PressureUpdater() {
        yield return new WaitForSeconds(updatePressureInterval);
        GamePlayManager.pressure = Random.Range(0.9f, 1.1f);
        Pressure.text = GamePlayManager.pressure.ToString();
        pressureCoroutine = StartCoroutine(PressureUpdater());
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


    public void UpdateReload () {
        if (GamePlayManager.Reload == latestReloadStatus)
            return;

        latestReloadStatus = GamePlayManager.Reload;

        this.Reload.SetActive(latestReloadStatus);
        if (latestReloadStatus) {
            reloadAnim.Play();
        } else {
            reloadAnim.Stop();
        }
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
        warnO2.SetActive(true);
        messageAnim.Play();
    }

    public void WarnCO2 () {
        warnCO2.SetActive(true);
        messageAnim.Play();
    }

    public void WarnPressure (bool isDecompression, float cntPressure) {
        if (isDecompression) {
            warnPressureReason.text = "Decompression";
        } else {
            warnPressureReason.text = "Compression";
        }
        warningPressure.text = cntPressure.ToString();
        warnPressure.SetActive(false);
        warnPressure.SetActive(true);
        messageAnim.Play();
    }

    public void WarnSytem () {
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

    private void StatusController () {
        CntSloat.text = GamePlayManager.cntSloat.ToString() + "(" + GamePlayManager.havingSloat.ToString() + ")";
        AllSloat.text = GamePlayManager.maxSloat.ToString();
        CntSloatProgress.value = GamePlayManager.cntSloat;
        AllSloatProgress.value = GamePlayManager.havingSloat;
        UpdateReload();
        if (GamePlayManager.playerSP != GamePlayManager.CNTPlayerSP) {
            SPandHPTimer = Time.deltaTime + SPandHPTimer;
        }

        if (Input.GetKeyUp(KeyCode.Return)) {
            if (GamePlayManager.CNTPlayerSP >= 1) {
                GamePlayManager.CNTPlayerSP -= 1;
                SP.value = GamePlayManager.CNTPlayerSP;
            } else {
                if (GamePlayManager.CNTPlayerHP >= 22) {
                    GamePlayManager.CNTPlayerHP -= 2;
                    HP.value = GamePlayManager.CNTPlayerHP;
                }
            }
            SPandHPTimer = 0;
        } else if (Input.GetKeyUp(KeyCode.Space) && !GamePlayManager.MessageShow) {
            if (GamePlayManager.CNTPlayerSP >= 2) {
                GamePlayManager.CNTPlayerSP -= 2;
                SP.value = GamePlayManager.CNTPlayerSP;
            } else {
                if (GamePlayManager.CNTPlayerHP >= 23) {
                    GamePlayManager.CNTPlayerHP -= 3;
                    HP.value = GamePlayManager.CNTPlayerHP;
                }
            }
            SPandHPTimer = 0;
        } else if (GamePlayManager.isRunning) {
            if (GamePlayManager.CNTPlayerSP >= 3) {
                GamePlayManager.CNTPlayerSP -= 3;
                SP.value = GamePlayManager.CNTPlayerSP;
            } else {
                if (GamePlayManager.CNTPlayerHP >= 25) {
                    GamePlayManager.CNTPlayerHP -= 5;
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
