using UnityEngine;
using UnityEngine.UI;

namespace Player.UI {
    public class PlayerSkillPoint : MonoBehaviour {
        [SerializeField] private bool isAdder;
        [SerializeField] private string option;
        
        private Button statController;
        private PlayerStatus status;
        private bool limited;

        private void Start() {
            statController = gameObject.GetComponent<Button>();
            status = FindObjectOfType<PlayerStatus>();
        }

        private void Update() {
            statController.interactable = limited;
        }

        private void LateUpdate() {
            if(isAdder) {
                limited = !(status.skillPoint - 1 < 0);
            } else {
                switch(option) {
                    case "health":
                        limited = !(status.healthPoint - 1 < 50);
                        break;
                    case "mana":
                        limited = !(status.manaPoint - 1 < 50);
                        break;
                    case "strength":
                        limited = !(status.strength - 1 < 3);
                        break;
                    case "defence":
                        limited = !(status.defence - 1 < 3);
                        break;
                    case "resistance":
                        limited = !(status.resistance - 1 < 3);
                        break;
                    case "intelligence":
                        limited = !(status.intelligence - 1 < 3);
                        break;
                    case "dexterity":
                        limited = !(status.dexterity - 1 < 3);
                        break;
                    case "agility":
                        limited = !(status.agility - 1 < 3);
                        break;
                    default:
                        Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                        break;
                }
            }
        }

        private void skillPointAdd() {
            switch(option) {
                case "health":
                    if(status.healthPoint.Equals(status.healthPointCNT)) {
                        status.healthPointCNT += 10;
                    }
                    status.healthPoint += 10;
                    status.skillPoint -= 1;
                    break;
                case "mana":
                    if(status.manaPoint.Equals(status.manaPointCNT)) {
                        status.manaPointCNT += 10;
                    }
                    status.manaPoint += 10;
                    status.skillPoint -= 1;
                    break;
                case "strength":
                    status.strength += 1;
                    status.skillPoint -= 1;
                    break;
                case "defence":
                    status.defence += 1;
                    status.skillPoint -= 1;
                    break;
                case "resistance":
                    status.resistance += 1;
                    status.skillPoint -= 1;
                    break;
                case "intelligence":
                    status.intelligence += 1;
                    status.skillPoint -= 1;
                    break;
                case "dexterity":
                    status.dexterity += 1;
                    status.skillPoint -= 1;
                    break;
                case "agility":
                    status.agility += 1;
                    status.skillPoint -= 1;
                    break;
                default:
                    Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                    break;
            }
        }
        
        private void skillPointSub() {
            switch(option) {
                case "health":
                    status.healthPoint -= 10;
                    if(status.healthPointCNT > status.healthPoint) {
                        status.healthPointCNT -= 10;
                    }
                    status.skillPoint += 1;
                    break;
                case "mana":
                    status.manaPoint -= 10;
                    if(status.manaPointCNT > status.manaPoint) {
                        status.manaPointCNT -= 10;
                    }
                    status.skillPoint += 1;
                    break;
                case "strength":
                    status.strength -= 1;
                    status.skillPoint += 1;
                    break;
                case "defence":
                    status.defence -= 1;
                    status.skillPoint += 1;
                    break;
                case "resistance":
                    status.resistance -= 1;
                    status.skillPoint += 1;
                    break;
                case "intelligence":
                    status.intelligence -= 1;
                    status.skillPoint += 1;
                    break;
                case "dexterity":
                    status.dexterity -= 1;
                    status.skillPoint += 1;
                    break;
                case "agility":
                    status.agility -= 1;
                    status.skillPoint += 1;
                    break;
                default:
                    Debug.LogWarningFormat("{0} is not correct form please check again and rerun game. ", option);
                    break;
            } 
        }
    }
}