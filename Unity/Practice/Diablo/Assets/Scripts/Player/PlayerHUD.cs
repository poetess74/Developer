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
        private PlayerInput input;
        private PlayerEXP maxEXP;

        private void Start() {
            status = GetComponent<PlayerStatus>();
            target = GetComponent<TargetSelector>();
            input = GetComponent<PlayerInput>();
            maxEXP = GetComponent<PlayerEXP>();
        }
        
        private void LateUpdate() {
            SyncPlayerInfo();
            SyncEnemyInfo();
        }

        private void SyncPlayerInfo() {
            playerHP.maxValue = status.healthPoint;
            playerHP.value = status.healthPointCNT;

            playerLV.text = GamePlayManager.instance.stageLV.ToString();

            playerEXP.maxValue = maxEXP.GetPlayerEXPMax();
            playerEXP.value = status.playerEXP;
        }
        
        private void SyncEnemyInfo() {
            enemyHP.gameObject.SetActive(input.target != null);
            enemyName.gameObject.SetActive(input.target != null);
            enemyGroup.gameObject.SetActive(input.target != null);

            if(input.target == null) return;
            
            enemyHP.maxValue = target.targetHP;
            enemyHP.value = target.targetCNTHP;

            enemyName.text = target.targetName;
            enemyGroup.text = target.targetGroup;
        }
    }
}