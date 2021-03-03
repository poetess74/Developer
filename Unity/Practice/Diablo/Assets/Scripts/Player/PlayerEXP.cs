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

        private void LevelUp() {
            status.healthPointCNT = status.healthPoint;
            status.manaPointCNT = status.manaPoint;
            status.skillPoint += 3;
            GamePlayManager.instance.stageLV++;
        }

        private bool LevelCap() {
            if(GamePlayManager.instance.stageLV >= 70) {
                status.playerEXP = 0f;
                expMax = 0f;
                return true;
            }
            return false;
        }

        public void AddPlayerEXP(float exp) {
            if(LevelCap()) return;
            
            status.playerEXP += exp;
            while(status.playerEXP > expMax) {
                LevelUp();
                if(LevelCap()) return;
                status.playerEXP -= expMax;
                expMax *= 2;
            }
        }
    }
}