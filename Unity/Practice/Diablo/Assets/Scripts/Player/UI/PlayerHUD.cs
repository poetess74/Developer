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
        
        private PlayerInit init;
        private TargetSelector target;
        private PlayerAttack player;
        private PlayerEXP maxEXP;

        private void Start() {
            init = GetComponent<PlayerInit>();
            target = GetComponent<TargetSelector>();
            player = GetComponent<PlayerAttack>();
            maxEXP = GetComponent<PlayerEXP>();
        }
        
        private void LateUpdate() {
            SyncPlayerInfo();
            SyncEnemyInfo();
        }

        private void SyncPlayerInfo() {
            playerHP.maxValue = init.healthPoint;
            playerHP.value = init.healthPointCNT;
            playerMP.maxValue = init.manaPoint;
            playerMP.value = init.manaPointCNT;

            for(int i = 0; i < playerHPText.Length; i++) {
                if(playerHPText[i].gameObject.activeSelf) 
                    playerHPText[i].text = $"{init.healthPointCNT}/{init.healthPoint} ({init.healthPointCNT / init.healthPoint * 100:F0}%)";
                if(playerMPText[i].gameObject.activeSelf) 
                    playerMPText[i].text = $"{init.manaPointCNT}/{init.manaPoint} ({init.manaPointCNT / init.manaPoint * 100:F0}%)";
                if(playerEXPText[i].gameObject.activeSelf) 
                    playerEXPText[i].text = $"{init.playerEXP:N1}/{maxEXP.GetPlayerEXPMax():N1} ({init.playerEXP / maxEXP.GetPlayerEXPMax() * 100:F0}%)";
            }

            playerLV.text = GamePlayManager.instance.stageLV.ToString();

            playerEXP.maxValue = maxEXP.GetPlayerEXPMax();
            playerEXP.value = init.playerEXP;
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