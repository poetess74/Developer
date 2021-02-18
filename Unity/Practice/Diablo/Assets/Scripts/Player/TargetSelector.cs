using Enemy;
using UnityEngine;

namespace Player {
    public class TargetSelector : MonoBehaviour {
        public string targetName { get; private set; }
        public string targetGroup { get; private set; }
        public float targetHP { get; private set; }
        public float targetCNTHP { get; private set; }

        private PlayerAttack player;
    
        private void Start() {
            player = GetComponent<PlayerAttack>();
        }

        private void Update() {
            if(player.target == null || player.target.Count == 0) return;
            targetName = player.target[0].GetComponent<EnemyDamage>().enemyName;
            targetGroup = player.target[0].GetComponent<EnemyDamage>().enemyGroup;
            targetHP = player.target[0].GetComponent<EnemyDamage>().enemyHP;
            targetCNTHP = player.target[0].GetComponent<EnemyDamage>().enemyCNTHP;
        }
    }
}
