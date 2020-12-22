using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using Random = UnityEngine.Random;

struct Skill {
    public string name;
    public int cost;
    public float castingTime;
    public float cooldownTime;
    public string iconPath;
    public string desc;
}

public class SkillTriggerController : MonoBehaviour {
    [SerializeField] private Slider launchingProgress;
    [SerializeField] private GameObject skillToolBar;
    
    [Header("Error Message Sound")]
    [SerializeField] private AudioClip noTarget;
    [SerializeField] private AudioClip notReadySkill;
    [SerializeField] private AudioClip oneSkillOnly;
    [SerializeField] private AudioClip wrongCMD;

    [Header("Low Resource Sound")]
    [SerializeField] private AudioClip lowFury;
    [SerializeField] private AudioClip moreFury;
    [SerializeField] private AudioClip lowWrath;
    [SerializeField] private AudioClip moreWrath;
    [SerializeField] private AudioClip lowMana;
    [SerializeField] private AudioClip moreMana;
    [SerializeField] private AudioClip lowArcane;
    [SerializeField] private AudioClip moreArcane;
    [SerializeField] private AudioClip lowHatred;
    [SerializeField] private AudioClip moreHatred;
    [SerializeField] private AudioClip lowDiscipline;
    [SerializeField] private AudioClip moreDiscipline;
    [SerializeField] private AudioClip lowSpirit;
    [SerializeField] private AudioClip moreSpirit;
    
    [Header("Skill Launching Sound")]
    [SerializeField] private AudioClip magicLaunching;
    [SerializeField] private AudioClip skillLaunching;
    
    public static SkillTriggerController skillTrigger;

    private AudioSource audioSource;

    private Dictionary<string, Skill> skillDict;
    private int skillKey;

    private void Awake() {
        skillTrigger = this;
        audioSource = GetComponent<AudioSource>();
        
        skillDict = new Dictionary<string, Skill>();
        
        var str = Resources.Load("SkillList") as TextAsset;
        var json = JSON.Parse(str.ToString());

        var skills = json["Skills"];

        foreach(var s in skills) {
            var skillNode = s.Value;
            Skill skill;
            skill.name = skillNode["name"].Value;
            skill.cost = int.Parse(skillNode["cost"].Value);
            skill.castingTime = float.Parse(skillNode["castingTime"].Value);
            skill.cooldownTime = float.Parse(skillNode["cooldownTime"].Value);
            skill.iconPath = skillNode["iconPath"].Value;
            skill.desc = skillNode["desc"].Value;
            skillDict[skill.name] = skill;
        }
    }

    private void Update() {
        launchingProgress.gameObject.SetActive(GamePlayManager.isLaunching);
    }

    public void skillLauncher(string skillName, KeyCode input) {
        if(GamePlayManager.TargetLV == 0) {
            WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            return;
        }
        if(skillName == null) {
            WarningController.warningController.ShowMessage("잘못된 명령입니다. ", wrongCMD);
            return;
        }
        if(GamePlayManager.isLaunching) {
            WarningController.warningController.ShowMessage("아직 스킬을 시전할 수 없습니다. ", notReadySkill);
            return;
        }

        skillKey = input switch {
            KeyCode.Alpha0 => 13,
            KeyCode.Alpha1 => 4,
            KeyCode.Alpha2 => 5,
            KeyCode.Alpha3 => 6,
            KeyCode.Alpha4 => 7,
            KeyCode.Alpha5 => 8,
            KeyCode.Alpha6 => 9,
            KeyCode.Alpha7 => 10,
            KeyCode.Alpha8 => 11,
            KeyCode.Alpha9 => 12,
            _ => skillKey
        };
        GamePlayManager.isLaunching = true;
        skillController(skillName, GamePlayManager.PlayerJob);
    }

    private void skillController(string skillName, string userJob) {
        float cost, castingTime, cooldownTime;
        try {
            var skill = skillDict[skillName];

            cost = skill.cost;
            castingTime = skill.castingTime;
            cooldownTime = skill.cooldownTime;
        } catch(ArgumentNullException e) {
            Debug.LogError("The argument value cannot be null setting default values... Please check 'JsonToObject(string, string)' function.\n" + e);
            cost = 3f;
            castingTime = 2f;
            cooldownTime = 2f;
        }

        if(GamePlayManager.PlayerCNTSP - cost < 0) {
            lowResource(userJob, false);
            return;
        }
        GamePlayManager.PlayerCNTSP -= cost;
        StartCoroutine(skillCastingTimer(castingTime, cooldownTime));
    }

    private void lowResource(string userJob, bool isDiscipline) {
        int source = Random.Range(0, 2);
        switch(userJob) {
            case "전사": 
                WarningController.warningController.ShowMessage(source == 0 ? "분노가 부족합니다. " : "분노가 더 필요합니다. ", source == 0 ? lowFury : moreFury);
                break;
            case "성기사":
                WarningController.warningController.ShowMessage(source == 0 ? "진노가 부족합니다. " : "진노가 더 필요합니다. ", source == 0 ? lowWrath: moreWrath);
                break;
            case "마법사":
                WarningController.warningController.ShowMessage(source == 0 ? "마나가 부족합니다. " : "마나가 더 필요합니다. ", source == 0 ? lowMana: moreMana);
                break;
            case "소서러":
                WarningController.warningController.ShowMessage(source == 0 ? "비젼력이 부족합니다. " : "비젼력이 더 필요합니다. ", source == 0 ? lowArcane: moreArcane);
                break;
            case "아처":
                if(isDiscipline) {
                    WarningController.warningController.ShowMessage(source == 0 ? "증오가 부족합니다. " : "증오가 더 필요합니다. ", source == 0 ? lowHatred: moreHatred);
                    break;
                } else {
                    WarningController.warningController.ShowMessage(source == 0 ? "절제가 부족합니다. " : "절제가 더 필요합니다. ", source == 0 ? lowDiscipline: moreDiscipline);
                    break;
                }
            case "도적":
                WarningController.warningController.ShowMessage(source == 0 ? "공력이 부족합니다. " : "공력이 더 필요합니다. ", source == 0 ? lowSpirit: moreSpirit);
                break;
        }
        GamePlayManager.isLaunching = false;
    }

    IEnumerator skillCastingTimer(float limit, float cooldownTime) {
        float timer = 0f;
        launchingProgress.maxValue = limit;
        var button = skillToolBar.transform.GetChild(skillKey).gameObject;
        var progressBar= button.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        progressBar.SetActive(true);
        while(limit > timer) {
            yield return new WaitForSeconds(0.1f);
            CircleProgressController.circleProgressController.setProgressValue(timer, limit);
            launchingProgress.value = timer;
            timer += 0.1f;
        }
        launchingProgress.value = 0;
        GamePlayManager.isLaunching = false;
        StartCoroutine(skillCooldownTimer(cooldownTime));
    }

    IEnumerator skillCooldownTimer(float limit) {
        float timer = 0f;
        while(limit > timer) {
            yield return new WaitForSeconds(0.1f);
            CircleProgressController.circleProgressController.setProgressValue(timer, limit);
            timer += 0.1f;
        }
        CircleProgressController.circleProgressController.disableProgress();
    }
}
