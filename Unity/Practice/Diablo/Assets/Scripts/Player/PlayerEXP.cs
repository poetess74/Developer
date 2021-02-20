using UnityEngine;

namespace Player {
    public class PlayerEXP : MonoBehaviour {

        private PlayerStatistics statistics;

        private void Start() {
            statistics = GetComponent<PlayerStatistics>();
            statistics.playerEXP = 0f;
        }

        public void AddPlayerEXP(float exp) {
            if((statistics.playerEXP + exp) > Mathf.Pow(128, GamePlayManager.instance.stageLV)) {
                GamePlayManager.instance.stageLV++;
                statistics.playerEXP = Mathf.Abs(statistics.playerEXP - exp);
                statistics.LevelUp();
            } else {
                statistics.playerEXP += exp;
            }
        }

        public float GetPlayerEXPMax() {
            return Mathf.Pow(128, GamePlayManager.instance.stageLV);
        }
    }
}