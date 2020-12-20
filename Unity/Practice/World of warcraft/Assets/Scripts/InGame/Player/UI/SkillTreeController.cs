using UnityEngine;

public class SkillTreeController : MonoBehaviour {
    [SerializeField] private GameObject[] skillList;
    void Start() {
        foreach(var index in skillList) {
            index.SetActive(false);
        }
    }

    void Update() {
        if(GamePlayManager.PlayerLV < 10) {
            for(int i = 0; i < GamePlayManager.PlayerLV; i++) {
                skillList[i].SetActive(true);
            }
        }
    }
}
