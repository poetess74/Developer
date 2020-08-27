using System;
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
    [SerializeField] private Animation targetingAnim;
    [SerializeField] private Animation HPlowWarning;
    [SerializeField] private Animation SPlowWarning;
    [SerializeField] private Animation CNTlowWarning;
    [SerializeField] private Animation ALLlowWarning;

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

    [SerializeField] private Text TargetName;
    [SerializeField] private Text TargetRank;
    [SerializeField] private Slider TargetHP;

    [SerializeField] private GameObject Communication;
    [SerializeField] private Text ComunicationText;
    [SerializeField] private GameObject Unable;
    [SerializeField] private GameObject Lock;

    [SerializeField] private GameObject Reload;

    [SerializeField] private GameObject MessageBox;
    [SerializeField] private Text MessageTitle;
    [SerializeField] private Text MessageText;

    private bool weaponHUDOn;
    private bool isTargetAnimPlayed = true;
    private string lastTargetStatus;
    private bool latestReloadStatus;
    private Coroutine hideCoroutine = null;
    private Coroutine expiredTarget = null;

    private void Awake () {
        Instance = this;
    }

    private void Start() {
        Name.text = PlayerDB.playerName;
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (weaponHUDOn) {
                WeaponHUDOff();
            } else {
                WeaponHUDOn();
            }
            weaponHUDOn = !weaponHUDOn;
            PlayerDB.WeaponEnable = !PlayerDB.WeaponEnable;
        }
        OpenHUD();
    }

    private void LateUpdate () {
        StatusUpdater();
        SyncMaxUnit();
        StatusWarning();
    }

    private void FixedUpdate () {
        Communications();
        Unables();
        Locks();
        ShowMessageBox();
    }

    private IEnumerator CloseHUD() {
        yield return new WaitForSeconds(3f);
        targetingAnim.Play("TargetTerminate");
        TargetName.text = "";
        closeCoroutine = null;
    }

    private Coroutine closeCoroutine = null;
    
    private void OpenHUD() {
        if (General.Target != null && !General.Target.CompareTag("Ground") && !General.Target.CompareTag("Weapon")) {
            if (General.Target.name != lastTargetStatus) {
                if(closeCoroutine != null) {
                    StopCoroutine(closeCoroutine);
                    closeCoroutine = null;
                }
                isTargetAnimPlayed = lastTargetStatus != null;
            }
            lastTargetStatus = General.Target.name;
        } else {
            if(lastTargetStatus != null)
                isTargetAnimPlayed = false;
            lastTargetStatus = null;
            if(isTargetAnimPlayed) return;
            isTargetAnimPlayed = true;
            if (closeCoroutine == null)
                closeCoroutine = StartCoroutine(CloseHUD());
            return;
        }
        
        switch(General.Target.tag) {
            case "Helper": 
                TargetHP.maxValue = NPCDB.NPCFHP;
                TargetHP.value = NPCDB.NPCHP;
                TargetRank.text = NPCDB.NPCRank;
                TargetName.text = General.Target.name;
                if(!isTargetAnimPlayed) {
                    targetingAnim.Play("TargetActive");
                    isTargetAnimPlayed = true;
                }
                break;
            case "Shuttle":
                TargetHP.maxValue = ShuttleDB.MAXshuttleDurability;
                TargetHP.value = ShuttleDB.CNTshuttleDurability;
                TargetRank.text = ShuttleDB.shuttleRank;
                TargetName.text = General.Target.name;
                if(!isTargetAnimPlayed) {
                    targetingAnim.Play("TargetActive");
                    isTargetAnimPlayed = true;
                }
                break;
            default:
                expiredTarget = StartCoroutine(ExpiredTarget());
                break;
        }
        Debug.Log(TargetName.text + " MaxHP: " + TargetHP.maxValue + ", " + TargetName.text + " HP: " + TargetHP.value);
        
        if (General.Target != null) {
            if (General.Target.name != lastTargetStatus) 
                isTargetAnimPlayed = false;
            lastTargetStatus = General.Target.name;
        } else {
            if(lastTargetStatus != null) {
                isTargetAnimPlayed = false;
                lastTargetStatus = null;
            }
        }
    }

    private IEnumerator ExpiredTarget() {
        yield return new WaitForSeconds(3f);
        if (General.Target != null) {
            if (General.Target.name != lastTargetStatus) 
                isTargetAnimPlayed = false;
            lastTargetStatus = General.Target.name;
        }
        
    }

    private void SyncMaxUnit () {
        CntSloatProgress.maxValue = PlayerDB.sloatUnit;
        AllSloatProgress.maxValue = PlayerDB.maxSloat;
        HP.maxValue = PlayerDB.playerHP;
        SP.maxValue = PlayerDB.playerSP;
    }

    private void StatusWarning() {
        WarnPressure(PlayerDB.pressure < 0.8f, PlayerDB.pressure > 1.3f, PlayerDB.pressure);
        float ratioHP, ratioSP, ratioCNTSloat, ratioHAVESloat;

        ratioHP = ((float)PlayerDB.CNTPlayerHP / PlayerDB.playerHP) * 100;
        ratioSP = ((float)PlayerDB.CNTPlayerSP / PlayerDB.playerSP) * 100;
        ratioCNTSloat = ((float)PlayerDB.cntSloat / PlayerDB.sloatUnit) * 100;
        ratioHAVESloat = ((float)PlayerDB.havingSloat / PlayerDB.maxSloat) * 100;
        
        if (ratioHP <= 20) {
            HPlowWarning.Play();
        } else if (HPlowWarning.isPlaying) {
            HPlowWarning.Rewind();
            HP.transform.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f);
            HPlowWarning.Stop();
        }
        
        if (ratioSP <= 20) {
            SPlowWarning.Play();
        } else if (SPlowWarning.isPlaying) {
            SPlowWarning.Rewind();
            SP.transform.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f);
            SPlowWarning.Stop();
        }
        
        if (ratioCNTSloat <= 25) {
            CNTlowWarning.Play();
        } else if (CNTlowWarning.isPlaying) {
            CNTlowWarning.Rewind();
            CntSloatProgress.transform.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f);
            CNTlowWarning.Stop();
        }
        
        if (ratioHAVESloat <= 10) {
            ALLlowWarning.Play();
        } else if (ALLlowWarning.isPlaying) {
            ALLlowWarning.Rewind();
            AllSloatProgress.transform.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f);
            ALLlowWarning.Stop();
        }        
    }

    private void Communications () {
        Communication.SetActive(PlayerDB.communicationBool);
        if (PlayerDB.communicationBool) {
            ComunicationText.text = PlayerDB.whoIs;
        }
    }

    private void Unables () {
        Unable.SetActive(PlayerDB.Unable);
    }

    private void Locks () {
        Lock.SetActive(PlayerDB.Lock);
    }


    private void UpdateReload () {
        if (PlayerDB.Reload == latestReloadStatus)
            return;

        latestReloadStatus = PlayerDB.Reload;

        Reload.SetActive(latestReloadStatus);
        if (latestReloadStatus) {
            reloadAnim.Play();
        } else {
            reloadAnim.Stop();
        }
    }

    private void ShowMessageBox () {
        if (General.MessageShow) {
            MessageBox.SetActive(General.MessageShow);
            MessageTitle.text = General.MessageTitle;
            MessageText.text = General.MessageText;
            if (Input.GetKeyUp(KeyCode.Space)) {
                General.NextMessage = true;
            }
        } else {
            MessageBox.SetActive(General.MessageShow);
        }
    }

    private void WarnO2 () {
        warnO2.SetActive(true);
        messageAnim.Play();
        warnO2.SetActive(false);
    }

    private void WarnCO2 () {
        warnCO2.SetActive(true);
        messageAnim.Play();
        warnCO2.SetActive(false);
    }

    private void WarnPressure (bool isDecompression, bool isCompression, float cntPressure) {
        if (!isDecompression && !isCompression) {
            return;
        }

        if (isDecompression) {
            warnPressureReason.text = "Decompression";
        } else if (isCompression) {
            warnPressureReason.text = "Compression";
        }
        warningPressure.text = cntPressure.ToString();
        warnPressure.SetActive(false);
        warnPressure.SetActive(true);
        messageAnim.Play();
    }

    private void WarnSytem (string title, string message) {
        warnSystemFailureTitle.text = title;
        warnSystemFailureMsg.text = message;
        warnSystem.SetActive(true);
        messageAnim.Play();
    }

    private void WeaponHUDOn () {
        WeaponName.text = PlayerDB.WeaponName;
        AttectPointer.SetActive(true);
        weaponAnim.Play("WeaponActive");
        DefaultPointer.SetActive(false);
    }

    private void WeaponHUDOff () {
        DefaultPointer.SetActive(true);
        weaponAnim.Play("WeaponTerminate");
        AttectPointer.SetActive(false);
        if (closeCoroutine == null)
            closeCoroutine = StartCoroutine(CloseHUD());
        TargetName.text = "";
        closeCoroutine = null;
    }

    private void StatusUpdater () {
        CntSloat.text = PlayerDB.cntSloat.ToString() + "(" + PlayerDB.havingSloat.ToString() + ")";
        AllSloat.text = PlayerDB.maxSloat.ToString();
        Pressure.text = PlayerDB.pressure.ToString();
        CntSloatProgress.value = PlayerDB.cntSloat;
        AllSloatProgress.value = PlayerDB.havingSloat;
        UpdateReload();
        SP.value = PlayerDB.CNTPlayerSP;
        HP.value = PlayerDB.CNTPlayerHP;
    }
}
