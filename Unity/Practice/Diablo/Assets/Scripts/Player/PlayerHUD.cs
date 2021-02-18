using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class PlayerHUD : MonoBehaviour {
        [Header("Player")]
        [SerializeField] private Slider playerHP;
        [SerializeField] private Slider playerMP;
        [SerializeField] private Slider playerEXP;
        [SerializeField] private Text playerLV;

        [Header("Enemy")] 
        [SerializeField] private Text enemyName;
        [SerializeField] private Text enemyGroup;
        [SerializeField] private Slider enemyHP;
        
        private PlayerStatus status;
        private TargetSelector target;
        private PlayerAttack player;
        private PlayerEXP maxEXP;

        private void Start() {
            status = GetComponent<PlayerStatus>();
            target = GetComponent<TargetSelector>();
            player = GetComponent<PlayerAttack>();
            maxEXP = GetComponent<PlayerEXP>();
        }
        
        private void LateUpdate() {
            SyncPlayerInfo();
            SyncEnemyInfo();
        }

        private void SyncPlayerInfo() {
            playerHP.maxValue = status.healthPoint;
            playerHP.value = status.healthPointCNT;
            playerMP.maxValue = status.manaPoint;
            playerMP.value = status.manaPointCNT;

            playerLV.text = GamePlayManager.instance.stageLV.ToString();

            playerEXP.maxValue = maxEXP.GetPlayerEXPMax();
            playerEXP.value = status.playerEXP;
        }
        
        private void SyncEnemyInfo() {
            enemyHP.gameObject.SetActive(player.target.Count != 0);
            enemyName.gameObject.SetActive(player.target.Count != 0);
            enemyGroup.gameObject.SetActive(player.target.Count != 0);

            if(player.target.Count == 0) return;
            
            enemyHP.maxValue = target.targetHP;
            enemyHP.value = target.targetCNTHP;

            enemyName.text = target.targetName;
            enemyGroup.text = target.targetGroup;
        }
    }
}