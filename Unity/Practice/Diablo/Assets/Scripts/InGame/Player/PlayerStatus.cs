using System.Collections;
using UnityEngine;

namespace InGame.Player {
    public class PlayerStatus: MonoBehaviour {
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

        private void Awake() {
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
        private void Start() {
            StartCoroutine(ResourceCharger());
        }

        private IEnumerator ResourceCharger() {
            while(true) {
                manaPointCNT += Utility.remainResourceProcess(manaPoint, manaPointCNT, 0.5f);
                yield return new WaitForSeconds(10f);
            }
        }
    }
}
