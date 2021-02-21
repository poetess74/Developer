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
        
        private Player.PlayerStatus status;
        private TargetSelector target;
        private PlayerAttack player;
        private PlayerEXP maxEXP;

        private void Start() {
            status = GetComponent<Player.PlayerStatus>();
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

            for(int i = 0; i < playerHPText.Length; i++) {
                if(playerHPText[i].gameObject.activeSelf) 
                    playerHPText[i].text = $"{status.healthPointCNT:N1}/{status.healthPoint:N1} ({status.healthPointCNT / status.healthPoint * 100:F1}%)";
                if(playerMPText[i].gameObject.activeSelf) 
                    playerMPText[i].text = $"{status.manaPointCNT:N1}/{status.manaPoint:N1} ({status.manaPointCNT / status.manaPoint * 100:F1}%)";
                if(playerEXPText[i].gameObject.activeSelf) 
                    playerEXPText[i].text = $"{status.playerEXP:N1}/{maxEXP.expMax:N1} ({status.playerEXP / maxEXP.expMax * 100:F1}%)";
            }

            playerLV.text = GamePlayManager.instance.stageLV.ToString();

            playerEXP.maxValue = maxEXP.expMax;
            playerEXP.value = status.playerEXP;
        }
        
        private void SyncEnemyInfo() {
            enemyHP.gameObject.SetActive(player.target.Count != 0);
            enemyName.gameObject.SetActive(player.target.Count != 0);
            enemyGroup.gameObject.SetActive(player.target.Count != 0);

            if(player.target.Count == 0) return;
            
            enemyHP.maxValue = target.targetHP;
            enemyHP.value = target.targetCNTHP;

            if(enemyHPText.gameObject.activeSelf) 
                enemyHPText.text = $"{target.targetCNTHP:N1}/{target.targetHP:N1} ({target.targetCNTHP / target.targetHP * 100:F1}%)";
            

            enemyName.text = target.targetName;
            enemyGroup.text = target.targetGroup;
        }
    }
}