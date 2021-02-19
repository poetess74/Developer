using Player.UI;
using UnityEngine;

namespace Player {
    public class PlayerEXP : MonoBehaviour {

        private PlayerInit init;

        private void Start() {
            init = GetComponent<PlayerInit>();
            init.playerEXP = 0f;
        }

        public void AddPlayerEXP(float exp) {
            if((init.playerEXP + exp) > Mathf.Pow(128, GamePlayManager.instance.stageLV)) {
                GamePlayManager.instance.stageLV++;
                init.playerEXP = Mathf.Abs(init.playerEXP - exp);
                init.LevelUp();
            } else {
                init.playerEXP += exp;
            }
        }

        public float GetPlayerEXPMax() {
            return Mathf.Pow(128, GamePlayManager.instance.stageLV);
        }
    }
}