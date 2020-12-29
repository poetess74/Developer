using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using Random = UnityEngine.Random;

struct Skill {
    public int shortcut;
    public string name;
    public int cost;
    public float castingTime;
    public float cooldownTime;
    public string iconPath;
    public string desc;
}

public class SkillTriggerController : MonoBehaviour {
    [Header("Player UI")]
    [SerializeField] private Slider launchingProgress;
    [SerializeField] private GameObject skillToolBar;
    [SerializeField] private Text skillName;
    
    [Header("Error Message Sound")]
    [SerializeField] private AudioClip noTarget;
    [SerializeField] private AudioClip notReadySkill;
    [SerializeField] private AudioClip interruptedSkill;
    [SerializeField] private AudioClip moveClose;
    [SerializeField] private AudioClip outOfRange;
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

    private Dictionary<int, Skill> skillDict;
    private int skillKeyCode;
    private bool[] skillcoolTime = new bool[10];

    private void Awake() {
        skillTrigger = this;
        audioSource = GetComponent<AudioSource>();
        
        skillDict = new Dictionary<int, Skill>();
        
        var str = Resources.Load("SkillList") as TextAsset;
        var json = JSON.Parse(str.ToString());

        if (GamePlayManager.PlayerJob == null) return;
        var skills = json[GamePlayManager.PlayerJob];

        foreach(var s in skills) {
            var skillNode = s.Value;
            Skill skill;
            skill.shortcut = int.Parse(skillNode["shortcut"].Value);
            skill.name = skillNode["name"].Value;
            skill.cost = int.Parse(skillNode["cost"].Value);
            skill.castingTime = float.Parse(skillNode["castingTime"].Value);
            skill.cooldownTime = float.Parse(skillNode["cooldownTime"].Value);
            skill.iconPath = skillNode["iconPath"].Value;
            skill.desc = skillNode["desc"].Value;
            skillDict[skill.shortcut] = skill;
        }
    }

    private void Update() {
        launchingProgress.gameObject.SetActive(GamePlayManager.isLaunching);
    }

    public void skillLauncher(KeyCode input) {
        skillKeyCode = input switch {
            KeyCode.Alpha0 => 0,
            KeyCode.Alpha1 => 1,
            KeyCode.Alpha2 => 2,
            KeyCode.Alpha3 => 3,
            KeyCode.Alpha4 => 4,
            KeyCode.Alpha5 => 5,
            KeyCode.Alpha6 => 6,
            KeyCode.Alpha7 => 7,
            KeyCode.Alpha8 => 8,
            KeyCode.Alpha9 => 9,
            _ => skillKeyCode
        };  
        
        if(GamePlayManager.TargetLV == 0) {
            WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            return;
        }
        if(Vector3.Distance(GamePlayManager.target.transform.position, transform.position) >= 20f) {
            int source = Random.Range(0, 2);
            WarningController.warningController.ShowMessage(source == 0 ? "좀더 가까이 가야 합니다. " : "대상이 사정거리 밖에 있습니다. ", source == 0 ? moveClose : outOfRange);
            return;
        }
        if(GamePlayManager.isLaunching && !skillcoolTime[skillKeyCode]) {
            WarningController.warningController.ShowMessage("한번에 하나의 스킳만 시전할 수 있습니다. ", oneSkillOnly);
            return;
        }
        if(GamePlayManager.isLaunching || skillcoolTime[skillKeyCode]) {
            WarningController.warningController.ShowMessage("아직 스킬을 시전할 수 없습니다. ", notReadySkill);
            return;
        }
        
        GamePlayManager.isLaunching = true;
        GamePlayManager.isBattle = true;
        skillController(skillKeyCode);
    }

    private void skillController(int keyCode) {
        float cost, castingTime, cooldownTime;
        try {
            var skill = skillDict[keyCode];

            cost = skill.cost;
            castingTime = skill.castingTime;
            cooldownTime = skill.cooldownTime;
        } catch(KeyNotFoundException e) {
            Debug.LogError("The argument value cannot be null. Please check 'SkillList.json' file.\n" + e);
            GamePlayManager.isLaunching = false;
            return;
        }

        if(GamePlayManager.PlayerCNTSP - cost < 0) {
            lowResource(GamePlayManager.PlayerJob, false);
            return;
        }
        StartCoroutine(skillCastingTimer(castingTime, cooldownTime, cost, skillKeyCode));
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

    private IEnumerator skillCastingTimer(float castTime, float cooldownTime, float cost, int keyCode) {
        float elapsedTime = 0f;
        Vector3 playerPos = transform.position;
        launchingProgress.maxValue = castTime;
        var skill = skillDict[keyCode];
        skillName.text = skill.name;
        ProgressController.progressController.progressInitializer(castTime);
        while(castTime > elapsedTime) {
            if(playerPos != transform.position) {
                ProgressController.progressController.resetProgress();
                WarningController.warningController.ShowMessage("기술을 시전하는 도중 방해를 받았습니다. ", interruptedSkill);
                GamePlayManager.isLaunching = false;
                break;
            }
            yield return new WaitForSeconds(0.01f);
            launchingProgress.value = elapsedTime;
            elapsedTime += 0.01f;
        }
        if(GamePlayManager.isLaunching) {
            launchingProgress.value = 0;
            GamePlayManager.isLaunching = false;
            GamePlayManager.PlayerCNTSP -= cost;
            skillcoolTime[keyCode] = true;
            ProgressController.progressController.progressInitializer(cooldownTime);
        }
        skillcoolTime[keyCode] = false;
    }
}
