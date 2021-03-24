using UnityEngine;
using UnityEngine.PlayerLoop;

namespace InGame.Player.UI {
    public class PlayerSkillSelector : MonoBehaviour {
        public GameObject[] skill;
        public GameObject[] trigger;

        private PlayerStatus status;
        
        [SerializeField] private GameObject[] lvCap;

        private void Start() {
            status = GetComponent<PlayerStatus>();
        }
        
        private void Update() {
            if(status.playerLV >= 3) {
                lvCap[0].SetActive(false);
                lvCap[1].SetActive(true);
                skill[1].SetActive(true);
                trigger[1].SetActive(true);
            }
            if(status.playerLV >= 5) {
                lvCap[1].SetActive(false);
                lvCap[2].SetActive(true);
                skill[2].SetActive(true);
                trigger[2].SetActive(true);
            }
            if(status.playerLV >= 10) {
                lvCap[2].SetActive(false);
                lvCap[3].SetActive(true);
                skill[3].SetActive(true);
                trigger[3].SetActive(true);
            }
            if(status.playerLV >= 20) {
                lvCap[3].SetActive(false);
                lvCap[4].SetActive(true);
                skill[4].SetActive(true);
                trigger[4].SetActive(true);
            }
            if(status.playerLV >= 30) {
                lvCap[4].SetActive(false);
                skill[5].SetActive(true);
                trigger[5].SetActive(true);
            }
        }
    }
}
