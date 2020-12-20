using UnityEngine;
using UnityEngine.UI;

public class CharInfoController : MonoBehaviour {
    [SerializeField] private Text userName;
    [SerializeField] private TextMesh userNamePublic;
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
        userNamePublic.text = GamePlayManager.PlayerName;
        userLV.text = GamePlayManager.PlayerLV.ToString();
        userHP.maxValue = GamePlayManager.PlayerHP;
        userSP.maxValue = GamePlayManager.PlayerSP;
    }

    private void Update() {
        userLV.text = GamePlayManager.PlayerLV.ToString();
        userHP.value = GamePlayManager.PlayerCNTHP;
        userSP.value = GamePlayManager.PlayerCNTSP;
        userHPText.text = GamePlayManager.PlayerCNTHP + " / " + GamePlayManager.PlayerHP;
        userSPText.text = GamePlayManager.PlayerCNTSP + " / " + GamePlayManager.PlayerSP;
    }
}
