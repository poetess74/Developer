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
        [SerializeField] private PlayerStatistics statistics;
        [SerializeField] private PlayerEXP maxEXP;
        
        private void Update() {
            lv.text = $"LV: {GamePlayManager.instance.stageLV}";
            hp.maxValue = statistics.healthPoint;
            hp.value = statistics.healthPointCNT;
            mp.maxValue = statistics.manaPoint;
            mp.value = statistics.manaPointCNT;

            exp.maxValue = maxEXP.GetPlayerEXPMax();
            exp.value = statistics.playerEXP;
            
            strength.text = $"STR: {statistics.strength - 3}";
            defence.text = $"DEF: {statistics.defence - 3}";
            resistance.text = $"REG: {statistics.resistance - 3}";
            intelligence.text = $"INT: {statistics.intelligence - 3}";
            dexterity.text = $"DEX: {statistics.dexterity - 3}";
            agility.text = $"AGI: {statistics.agility - 3}";
            skillPoint.text = $"Skill Point: {statistics.skillPoint}";
        }
    }
}