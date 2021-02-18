using UnityEngine;

namespace Player.UI {
    public class PlayerStatus: MonoBehaviour {
        public float healthPoint { get; private set; }
        [HideInInspector] public float healthPointCNT;
        public float manaPoint { get; private set; }
        [HideInInspector] public float manaPointCNT;
        
        public int strength { get; private set; }
        public int defence { get; private set; }
        public int resistance { get; private set; }
        public int intelligence { get; private set; }
        public int dexterity { get; private set; }
        public int agility { get; private set; }

        [HideInInspector] public float playerEXP;
        public int skillPoint { get; private set; }
        
        private void Start() {
            healthPoint = 50f;
            healthPointCNT = healthPoint;
            manaPoint = 50f;
            manaPointCNT = manaPoint;
            
            strength = 3;
            defence = 3;
            resistance = 3;
            intelligence = 3;
            dexterity = 3;
            agility = 3;
        }

        public void LevelUp() {
            skillPoint += 3;
        }
    }
}