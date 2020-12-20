using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailController : MonoBehaviour {
    [SerializeField] private Text charName;
    [SerializeField] private Text lv;
    
    private void LateUpdate() {
        charName.text = GamePlayManager.PlayerName;
        lv.text = GamePlayManager.PlayerLV.ToString("LV - #");
    }
}
