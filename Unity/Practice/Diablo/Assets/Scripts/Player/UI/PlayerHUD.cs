using UnityEngine;
using UnityEngine.UI;

namespace Player.UI {
    public class PlayerHUD : MonoBehaviour {
        [Header("Player")]
        [SerializeField] private Slider playerHP;
        [SerializeField] private Text[] playerHPText;
        [SerializeField] private Slider playerMP;
        [SerializeField] private Text[] playerMPText;
        [SerializeField] private Slider playerEXP;
        [SerializeField] private Text[] playerEXPText;
        [SerializeField] private Text playerLV;

        [Header("Enemy")] 
        [SerializeField] private Text enemyName;
        [SerializeField] private Text enemyGroup;
        [SerializeField] private Slider enemyHP;
        [SerializeField] private Text enemyHPText;
        
        private PlayerStatistics statistics;
        private TargetSelector target;
        private PlayerAttack player;
        private PlayerEXP maxEXP;

        private void Start() {
            statistics = GetComponent<PlayerStatistics>();
            target = GetComponent<TargetSelector>();
            player = GetComponent<PlayerAttack>();
            maxEXP = GetComponent<PlayerEXP>();
        }
        
        private void LateUpdate() {
            SyncPlayerInfo();
            SyncEnemyInfo();
        }

        private void SyncPlayerInfo() {
            playerHP.maxValue = statistics.healthPoint;
            playerHP.value = statistics.healthPointCNT;
            playerMP.maxValue = statistics.manaPoint;
            playerMP.value = statistics.manaPointCNT;

            for(int i = 0; i < playerHPText.Length; i++) {
                if(playerHPText[i].gameObject.activeSelf) 
                    playerHPText[i].text = $"{statistics.healthPointCNT}/{statistics.healthPoint} ({statistics.healthPointCNT / statistics.healthPoint * 100:F0}%)";
                if(playerMPText[i].gameObject.activeSelf) 
                    playerMPText[i].text = $"{statistics.manaPointCNT}/{statistics.manaPoint} ({statistics.manaPointCNT / statistics.manaPoint * 100:F0}%)";
                if(playerEXPText[i].gameObject.activeSelf) 
                    playerEXPText[i].text = $"{statistics.playerEXP:N1}/{maxEXP.GetPlayerEXPMax():N1} ({statistics.playerEXP / maxEXP.GetPlayerEXPMax() * 100:F0}%)";
            }

            playerLV.text = GamePlayManager.instance.stageLV.ToString();

            playerEXP.maxValue = maxEXP.GetPlayerEXPMax();
            playerEXP.value = statistics.playerEXP;
        }
        
        private void SyncEnemyInfo() {
            enemyHP.gameObject.SetActive(player.target.Count != 0);
            enemyName.gameObject.SetActive(player.target.Count != 0);
            enemyGroup.gameObject.SetActive(player.target.Count != 0);

            if(player.target.Count == 0) return;
            
            enemyHP.maxValue = target.targetHP;
            enemyHP.value = target.targetCNTHP;

            if(enemyHPText.gameObject.activeSelf) 
                enemyHPText.text = $"{target.targetCNTHP}/{target.targetHP} ({target.targetCNTHP / target.targetHP * 100}%)";
            

            enemyName.text = target.targetName;
            enemyGroup.text = target.targetGroup;
        }
    }
}