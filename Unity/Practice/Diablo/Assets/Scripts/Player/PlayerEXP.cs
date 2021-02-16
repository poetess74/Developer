using UnityEngine;

namespace Player {
    public class PlayerEXP : MonoBehaviour {
        public float playerEXP { get; private set; }

        private void Start() {
            playerEXP = 0f;
        }

        public void AddPlayerEXP(float exp) {
            if((playerEXP + exp) > Mathf.Pow(128, GamePlayManager.instance.stageLV)) {
                GamePlayManager.instance.stageLV++;
                playerEXP = Mathf.Abs(playerEXP - exp);
            } else {
                playerEXP += exp;
            }
        }
    }
}