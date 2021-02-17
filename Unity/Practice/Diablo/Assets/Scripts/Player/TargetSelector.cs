using Enemy;
using UnityEngine;

namespace Player {
    public class TargetSelector : MonoBehaviour {
        private PlayerInput input;

        public string targetName { get; private set; }
        public string targetGroup { get; private set; }
        public float targetHP { get; private set; }
        public float targetCNTHP { get; private set; }
    
        private void Start() {
            input = GetComponent<PlayerInput>();
        }

        private void Update() {
            if(input.target == null) return;
            targetName = input.target.GetComponent<EnemyDamage>().enemyName;
            targetGroup = input.target.GetComponent<EnemyDamage>().enemyGroup;
            targetHP = input.target.GetComponent<EnemyDamage>().enemyHP;
            targetCNTHP = input.target.GetComponent<EnemyDamage>().enemyCNTHP;
        }
    }
}
