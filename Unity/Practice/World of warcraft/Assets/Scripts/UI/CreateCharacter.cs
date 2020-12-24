using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    [SerializeField] private InputField charName;
    [SerializeField] private Dropdown job;
    [SerializeField] private Dropdown gender;

    private void OnClick() {
        CreateUser();
        charName.text = "";
        job.value = 0;
        gender.value = 0;
    }

    private void CreateUser() {
        if(charName.text.Trim() == "") {
            charName.text = "게스트";
        }
        GamePlayManager.PlayerName = charName.text.Trim();
        GamePlayManager.PlayerJob = job.options[job.value].text;
        GamePlayManager.isMale = gender.options[gender.value].text == "남성";
        GamePlayManager.PlayerLV = 1;
        GamePlayManager.PlayerHP = 50;
        GamePlayManager.PlayerSP = 50;
        GamePlayManager.PlayerEXP = 120;
        GamePlayManager.PlayerCNTEXP = 0;
        GamePlayManager.PlayerCNTHP = 50;
        GamePlayManager.PlayerCNTSP = 50;
        GamePlayManager.PlayerLocation = new Vector3(1f, 0f, 1f);
    }
}
