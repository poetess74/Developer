using UnityEngine;

namespace Player {
    public class PlayerEXP : MonoBehaviour {
        [HideInInspector] public float expMax;

        private PlayerStatus status;

        private void Start() {
            status = GetComponent<PlayerStatus>();
            status.playerEXP = 0f;
            expMax = 400;
        }

        public void LevelUp() {
            status.healthPointCNT = status.healthPoint;
            status.manaPointCNT = status.manaPoint;
            status.skillPoint += 3;
            GamePlayManager.instance.stageLV++;
        }

        public void AddPlayerEXP(float exp) {
            status.playerEXP += exp;
            if(status.playerEXP > expMax) {
                LevelUp();
                status.playerEXP -= expMax;
                expMax *= 2;
            }
        }
    }
}