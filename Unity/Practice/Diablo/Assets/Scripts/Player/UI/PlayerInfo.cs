using UnityEngine;
using UnityEngine.UI;

namespace Player.UI {
    public class PlayerInfo : MonoBehaviour {
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
        [SerializeField] private Player.PlayerStatus status;
        [SerializeField] private PlayerEXP maxEXP;
        
        private void Update() {
            lv.text = $"LV: {GamePlayManager.instance.stageLV}";
            hp.maxValue = status.healthPoint;
            hp.value = status.healthPointCNT;
            mp.maxValue = status.manaPoint;
            mp.value = status.manaPointCNT;

            exp.maxValue = maxEXP.expMax;
            exp.value = status.playerEXP;
            
            strength.text = $"STR: {status.strength - 3}";
            defence.text = $"DEF: {status.defence - 3}";
            resistance.text = $"REG: {status.resistance - 3}";
            intelligence.text = $"INT: {status.intelligence - 3}";
            dexterity.text = $"DEX: {status.dexterity - 3}";
            agility.text = $"AGI: {status.agility - 3}";
            skillPoint.text = $"Skill Point: {status.skillPoint}";
        }
    }
}