using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    [SerializeField] private InputField charName;
    [SerializeField] private Dropdown job;

    private void OnClick() {
        CreateUser();
        charName.text = "";
        job.value = 0;
    }

    private void CreateUser() {
        GamePlayManager.PlayerName = charName.text;
        GamePlayManager.PlayerJob = job.options[job.value].text;
        GamePlayManager.PlayerLV = 1;
        GamePlayManager.PlayerHP = 50;
        GamePlayManager.PlayerSP = 50;
        GamePlayManager.PlayerEXP = 0;
        GamePlayManager.PlayerCNTHP = 50;
        GamePlayManager.PlayerCNTSP = 50;
    }
}
