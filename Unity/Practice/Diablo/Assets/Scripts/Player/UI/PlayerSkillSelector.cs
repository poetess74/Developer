using UnityEngine;

namespace Player.UI {
    public class PlayerSkillSelector : MonoBehaviour {
        public GameObject[] lvCap;
        public GameObject[] skill;
        public GameObject[] trigger;
        
        private void Update() {
            if(GamePlayManager.instance.stageLV >= 3) {
                lvCap[0].SetActive(false);
                lvCap[1].SetActive(true);
                skill[1].SetActive(true);
                trigger[1].SetActive(true);
            }
            if(GamePlayManager.instance.stageLV >= 5) {
                lvCap[1].SetActive(false);
                lvCap[2].SetActive(true);
                skill[2].SetActive(true);
                trigger[2].SetActive(true);
            }
            if(GamePlayManager.instance.stageLV >= 10) {
                lvCap[2].SetActive(false);
                lvCap[3].SetActive(true);
                skill[3].SetActive(true);
                trigger[3].SetActive(true);
            }
            if(GamePlayManager.instance.stageLV >= 20) {
                lvCap[3].SetActive(false);
                lvCap[4].SetActive(true);
                skill[4].SetActive(true);
                trigger[4].SetActive(true);
            }
            if(GamePlayManager.instance.stageLV >= 30) {
                lvCap[4].SetActive(false);
                skill[5].SetActive(true);
                trigger[5].SetActive(true);
            }
        }
    }
}