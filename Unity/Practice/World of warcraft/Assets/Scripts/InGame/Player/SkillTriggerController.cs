using UnityEngine;

public class SkillTriggerController : MonoBehaviour {
    [SerializeField] private AudioClip noTarget;
    [SerializeField] private AudioClip notReadySkill;
    
    public static SkillTriggerController skillTrigger;

    private void Awake() {
        skillTrigger = this;
    }
    
    public void skillLauncher(string skillName, string playerJob) {
        if(GamePlayManager.TargetLV == 0) {
            WarningController.warningController.ShowMessage("대상을 먼저 지정해야 합니다. ", noTarget);
        }
        if(skillName == null) {
            WarningController.warningController.ShowMessage("아직 스킬을 시전할 수 없습니다. ", notReadySkill);
        }
    }
}
