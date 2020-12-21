using System.Collections;
using UnityEngine;

public class SkillTriggerController : MonoBehaviour {
    [SerializeField] private AudioClip noTarget;
    [SerializeField] private AudioClip notReadySkill;
    [SerializeField] private AudioClip oneSkillOnly;

    [SerializeField] private AudioClip lowMana;
    
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
            WarningController.warningController.ShowMessage("아직 스킬을 시전할 수 없습니다. ", notReadySkill);
            return;
        }
        if(isLaunching) {
            WarningController.warningController.ShowMessage("한번에 한개의 스킬만 시전할 수 있습니다. ", oneSkillOnly);
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
                    WarningController.warningController.ShowMessage("마나가 부족합니다. ", lowMana);
                    isLaunching = false;
                    return;
                }
                GamePlayManager.PlayerCNTSP -= requireSP;
                elapseTime = 5;
                coolTime = 10;
                StartCoroutine(skillElapseTimer(elapseTime));
                break;
        }
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
