using UnityEngine;

namespace Player {
    public class PlayerInit: MonoBehaviour {
        [HideInInspector] public float healthPoint;
        [HideInInspector] public float healthPointCNT;
        [HideInInspector] public float manaPoint;
        [HideInInspector] public float manaPointCNT;

        [HideInInspector] public int strength;
        [HideInInspector] public int defence;
        [HideInInspector] public int resistance;
        [HideInInspector] public int intelligence;
        [HideInInspector] public int dexterity;
        [HideInInspector] public int agility;

        [HideInInspector] public float playerEXP;
        [HideInInspector] public int skillPoint;
        
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