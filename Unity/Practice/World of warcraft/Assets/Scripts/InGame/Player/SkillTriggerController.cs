using System.Collections;
using UnityEngine;

public class SkillTriggerController : MonoBehaviour {
    [SerializeField] private AudioClip noTarget;
    [SerializeField] private AudioClip notReadySkill;
    [SerializeField] private AudioClip oneSkillOnly;
    [SerializeField] private AudioClip wrongCMD;

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
    
    [SerializeField] private AudioClip magicLaunching;
    [SerializeField] private AudioClip skillLaunching;
    
    public static SkillTriggerController skillTrigger;

    private bool isLaunching;
    private AudioSource audioSource;

    private void Awake() {
        skillTrigger = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    public void skillLauncher(string skillName) {
        if(GamePlayManager.TargetLV == 0) {
            WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
            return;
        }
        if(skillName == null) {
            WarningController.warningController.ShowMessage("잘못된 명령입니다. ", wrongCMD);
            return;
        }
        if(isLaunching) {
            WarningController.warningController.ShowMessage("아직 스킬을 시전할 수 없습니다. ", notReadySkill);
            return;
        }

        isLaunching = true;
        skillController(skillName, GamePlayManager.PlayerJob);
    }

    private void skillController(string skillName, string userJob) {
        float requireHP, requireSP;
        float elapseTime, coolTime;
        switch(skillName) {
            case "HelloWorld":
                requireSP = 3f;
                if(GamePlayManager.PlayerCNTSP - requireSP < 0) {
                    lowResource(userJob, false);
                    return;
                }
                GamePlayManager.PlayerCNTSP -= requireSP;
                elapseTime = 5;
                coolTime = 10;
                StartCoroutine(skillElapseTimer(elapseTime));
                break;
        }
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
        isLaunching = false;
    }

    IEnumerator skillElapseTimer(float limit) {
        float timer = 0f;
        while(limit > timer) {
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }
        isLaunching = false;
    }
}
