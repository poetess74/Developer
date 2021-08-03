using UnityEngine;

namespace InGame.Player {
    public class PlayerEXP : MonoBehaviour {
        [HideInInspector] public float expMax;
        public readonly float MAX_EXP = 472236648286964521369600f;

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
            status.playerLV++;
        }

        private bool LevelCap() {
            if(status.playerLV >= 70) {
                status.playerEXP = 0f;
                expMax = 0f;
                return true;
            }
            return false;
        }

        public void AddPlayerEXP(float exp) {
            if(LevelCap()) return;
            
            status.playerEXP += exp;
            while(status.playerEXP >= expMax) {
                LevelUp();
                if(LevelCap()) return;
                status.playerEXP -= expMax;
                expMax *= 2;
            }
        }
    }
}
