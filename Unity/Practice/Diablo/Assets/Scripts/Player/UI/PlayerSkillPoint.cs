using UnityEngine;
using UnityEngine.UI;

namespace Player.UI {
    public class PlayerSkillPoint : MonoBehaviour {
        [SerializeField] private bool isAdder;
        [SerializeField] private string option;
        
        private Button statController;
        private PlayerStatistics statistics;
        private bool limited;

        private void Start() {
            statController = gameObject.GetComponent<Button>();
            statistics = FindObjectOfType<PlayerStatistics>();
        }

        private void Update() {
            statController.interactable = limited;
        }

        private void LateUpdate() {
            if(isAdder) {
                limited = !(statistics.skillPoint - 1 < 0);
            } else {
                switch(option) {
                    case "health":
                        limited = !(statistics.healthPoint - 1 < 50);
                        break;
                    case "mana":
                        limited = !(statistics.manaPoint - 1 < 50);
                        break;
                    case "strength":
                        limited = !(statistics.strength - 1 < 3);
                        break;
                    case "defence":
                        limited = !(statistics.defence - 1 < 3);
                        break;
                    case "resistance":
                        limited = !(statistics.resistance - 1 < 3);
                        break;
                    case "intelligence":
                        limited = !(statistics.intelligence - 1 < 3);
                        break;
                    case "dexterity":
                        limited = !(statistics.dexterity - 1 < 3);
                        break;
                    case "agility":
                        limited = !(statistics.agility - 1 < 3);
                        break;
                    default:
                        Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                        break;
                }
            }
        }

        public void skillPointAdd() {
            switch(option) {
                case "health":
                    statistics.healthPoint += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "mana":
                    statistics.manaPoint += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "strength":
                    statistics.strength += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "defence":
                    statistics.defence += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "resistance":
                    statistics.resistance += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "intelligence":
                    statistics.intelligence += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "dexterity":
                    statistics.dexterity += 1;
                    statistics.skillPoint -= 1;
                    break;
                case "agility":
                    statistics.agility += 1;
                    statistics.skillPoint -= 1;
                    break;
                default:
                    Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                    break;
            }
        }
        
        public void skillPointSub() {
            switch(option) {
                case "health":
                    statistics.healthPoint -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "mana":
                    statistics.manaPoint -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "strength":
                    statistics.strength -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "defence":
                    statistics.defence -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "resistance":
                    statistics.resistance -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "intelligence":
                    statistics.intelligence -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "dexterity":
                    statistics.dexterity -= 1;
                    statistics.skillPoint += 1;
                    break;
                case "agility":
                    statistics.agility -= 1;
                    statistics.skillPoint += 1;
                    break;
                default:
                    Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                    break;
            } 
        }
    }
}