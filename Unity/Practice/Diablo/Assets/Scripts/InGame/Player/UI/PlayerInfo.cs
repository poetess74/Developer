using Other;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Player.UI {
    public class PlayerInfo : MonoBehaviour {
        [HideInInspector] public bool isPatched;

        [Header("Basic")]
        [SerializeField] private Text name;
        [SerializeField] private Text playerID;
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
        [SerializeField] private PlayerStatus status;
        [SerializeField] private PlayerEXP maxEXP;

        private void Start() {
            playerID.text = $"PID: {Utility.randomString(12)}";
        }
        
        private void Update() {
            lv.text = $"LV: {status.playerLV}";
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

        private void LateUpdate() {
            if(isPatched) {
                playerID.text = "PID: N/A";
                guild.text = "Guild: N/A";
            }
        }
    }
}
