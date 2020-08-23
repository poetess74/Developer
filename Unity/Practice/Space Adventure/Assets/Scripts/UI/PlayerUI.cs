using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public static PlayerUI Instance;

    [SerializeField] private GameObject DefaultPointer;
    [SerializeField] private GameObject AttectPointer;

    [SerializeField] private Text Name;
    [SerializeField] private Text Pressure;
    [SerializeField] private Slider HP;
    [SerializeField] private Slider SP;

    [SerializeField] private Text WeaponName;
    [SerializeField] private Text CntSloat;
    [SerializeField] private Text AllSloat;
    [SerializeField] private Slider CntSloatProgress;
    [SerializeField] private Slider AllSloatProgress;

    [SerializeField] private Animation messageAnim;
    [SerializeField] private Animation weaponAnim;
    [SerializeField] private Animation reloadAnim;

    [SerializeField] private GameObject warnO2;
    [SerializeField] private GameObject warnCO2;
    [SerializeField] private GameObject warnPressure;
    [SerializeField] private GameObject warnSystem;

    [SerializeField] private Text warnO2Reason;
    [SerializeField] private Text warnO2Pressure;
    [SerializeField] private Text warnCO2Pressure;
    [SerializeField] private Text warnPressureReason;
    [SerializeField] private Text warningPressure;

    [SerializeField] private Text warnSystemFailureTitle;
    [SerializeField] private Text warnSystemFailureMsg;

    [SerializeField] private GameObject WeaponHUD;

    [SerializeField] private GameObject Communication;
    [SerializeField] private Text ComunicationText;
    [SerializeField] private GameObject Unable;
    [SerializeField] private GameObject Lock;

    [SerializeField] private GameObject Reload;
    [SerializeField] private GameObject UnableLanuch;

    [SerializeField] private GameObject MessageBox;
    [SerializeField] private Text MessageTitle;
    [SerializeField] private Text MessageText;

    private float updatePressureInterval = 1f;
    private bool latestReloadStatus;
    private Coroutine pressureCoroutine;
    
    private void Awake () {
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

    private void Communications () {
        this.Communication.SetActive(GamePlayManager.communicationBool);
        if (GamePlayManager.communicationBool) {
            this.ComunicationText.text = GamePlayManager.whoIs;
        }
    }

    private void Unables () {
        this.Unable.SetActive(GamePlayManager.Unable);
    }

    private void Locks () {
        this.Lock.SetActive(GamePlayManager.Lock);
    }


    private void UpdateReload () {
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

    private void UnableLaunches () {
        this.UnableLanuch.SetActive(GamePlayManager.UnableLaunch);
    }

    private void ShowMessageBox () {
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

    private void TurnOffAllWarns () {
        warnO2.SetActive(false);
        warnCO2.SetActive(false);
        warnPressure.SetActive(false);
        warnSystem.SetActive(false);
    }

    private void WarnO2 () {
        warnO2.SetActive(true);
        messageAnim.Play();
    }

    private void WarnCO2 () {
        warnCO2.SetActive(true);
        messageAnim.Play();
    }

    private void WarnPressure (bool isDecompression, float cntPressure) {
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

    private void WarnSytem () {
        warnSystem.SetActive(true);
        messageAnim.Play();
    }

    private void WeaponHUDOn () {
        AttectPointer.SetActive(true);
        weaponAnim.Play("WeaponActive");
        DefaultPointer.SetActive(false);
    }

    private void WeaponHUDOff () {
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
