using UnityEngine;

namespace Player {
    public class PlayerStatus: MonoBehaviour {
        public int healthPoint { get; private set; }
        public int healthPointCNT;
        public int manaPoint { get; private set; }
        
        public int strength { get; private set; }
        public int defence { get; private set; }
        public int resistance { get; private set; }
        public int intelligence { get; private set; }
        public int dexterity { get; private set; }
        public int agility { get; private set; }

        public float playerEXP;
        public int skillPoint { get; private set; }
        
        private void Start() {
            healthPoint = 50;
            healthPointCNT = healthPoint;
            manaPoint = 50;
            
            //TODO: When inspector window each -3 status (except default values when user sub skill point(s)). 
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