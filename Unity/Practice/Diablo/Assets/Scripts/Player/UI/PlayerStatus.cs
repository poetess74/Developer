using UnityEngine;
using UnityEngine.UI;

namespace Player.UI {
    public class PlayerStatus : MonoBehaviour {
        [Header("Basic")]
        [SerializeField] private Text name;
        [SerializeField] private Text guild;
        [SerializeField] private Text lv;
        [SerializeField] private Slider hp;
        [SerializeField] private Slider mp;
        [SerializeField] private Slider exp;

        [Header("Detail")]
        [SerializeField] private Text strength;
        [SerializeField] private Text defence;
        [SerializeField] private Text resistance;
        [SerializeField] private Text intelligence;
        [SerializeField] private Text dexterity;
        [SerializeField] private Text agility;
        [SerializeField] private Text skillPoint;

        [Header("Get Status")]
        [SerializeField] private PlayerInit init;
        [SerializeField] private PlayerEXP maxEXP;
        
        private void OnEnable() {
            lv.text = $"LV: {GamePlayManager.instance.stageLV}";
            hp.maxValue = init.healthPoint;
            hp.value = init.healthPointCNT;
            mp.maxValue = init.manaPoint;
            mp.value = init.manaPointCNT;

            exp.maxValue = maxEXP.GetPlayerEXPMax();
            exp.value = init.playerEXP;
            
            strength.text = $"STR: {init.strength - 3}";
            defence.text = $"DEF: {init.defence - 3}";
            resistance.text = $"REG: {init.resistance - 3}";
            intelligence.text = $"INT: {init.intelligence - 3}";
            dexterity.text = $"DEX: {init.dexterity - 3}";
            agility.text = $"AGI: {init.agility - 3}";
            skillPoint.text = $"Skill Point: {init.skillPoint}";
        }
    }
}