using UnityEngine;
using UnityEngine.UI;

public class CharInfoController : MonoBehaviour {
    [SerializeField] private Text userName;
    [SerializeField] private Text userLV;
    [SerializeField] private Image userProfile;
    [SerializeField] private Image userJob;
    [SerializeField] private Slider userHP;
    [SerializeField] private Text userHPText;
    [SerializeField] private Slider userSP;
    [SerializeField] private Text userSPText;
    [SerializeField] private Slider userEXP;
    [SerializeField] private Text userEXPText;
    
    private void Start() {
        userName.text = GamePlayManager.PlayerName;
        userLV.text = GamePlayManager.PlayerLV.ToString();
        userHP.maxValue = GamePlayManager.PlayerHP;
        userSP.maxValue = GamePlayManager.PlayerSP;
        Image userSPSprite = userSP.fillRect.GetComponent<Image>();
        switch(GamePlayManager.PlayerJob) {
            case "전사":
                userSPSprite.color = new Color(1f, 0.5f, 0f);
                break;
            case "성기사":
                userSPSprite.color = new Color(1f, 1f, 1f);
                break;
            case "마법사":
                userSPSprite.color = new Color(0f, 0f, 1f);
                break;
            case "소서러":
                userSPSprite.color = new Color(1f, 0f, 1f);
                break;
            case "아처":
                userSPSprite.color = new Color(1f, 0f, 0f);
                break;
            case "도적":
                userSPSprite.color = new Color(1f, 1f, 0f);
                break;
        }
    }

    private void Update() {
        userLV.text = GamePlayManager.PlayerLV.ToString();
        userHP.value = GamePlayManager.PlayerCNTHP;
        userSP.value = GamePlayManager.PlayerCNTSP;
        userHP.maxValue = GamePlayManager.PlayerHP;
        userSP.maxValue = GamePlayManager.PlayerSP;
        userHPText.text = GamePlayManager.PlayerCNTHP + " / " + GamePlayManager.PlayerHP;
        userSPText.text = GamePlayManager.PlayerCNTSP + " / " + GamePlayManager.PlayerSP;
        userEXP.maxValue = GamePlayManager.PlayerEXP;
        userEXP.value = GamePlayManager.PlayerCNTEXP;
        userEXPText.text = GamePlayManager.PlayerCNTEXP + " / " + GamePlayManager.PlayerEXP;
    }
}
