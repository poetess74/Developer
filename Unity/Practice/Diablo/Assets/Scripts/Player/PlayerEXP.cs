using UnityEngine;

namespace Player {
    public class PlayerEXP : MonoBehaviour {

        private PlayerStatus status;

        private void Start() {
            status = GetComponent<PlayerStatus>();
            status.playerEXP = 0f;
        }

        public void AddPlayerEXP(float exp) {
            if((status.playerEXP + exp) > Mathf.Pow(128, GamePlayManager.instance.stageLV)) {
                GamePlayManager.instance.stageLV++;
                status.playerEXP = Mathf.Abs(status.playerEXP - exp);
                status.LevelUp();
            } else {
                status.playerEXP += exp;
            }
        }
    }
}