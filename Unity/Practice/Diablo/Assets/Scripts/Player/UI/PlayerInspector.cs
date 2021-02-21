using UnityEngine;

namespace Player.UI {
    public class PlayerInspector : MonoBehaviour {
        
        private GameObject itemWindow;
        private GameObject skillWindow;
        private GameObject statusWindow;

        private void Start() {
            itemWindow = transform.GetChild(0).gameObject;
            skillWindow = transform.GetChild(1).gameObject;
            statusWindow = transform.GetChild(2).gameObject;
        }

        private void Update() {
            if(GamePlayManager.instance.isGameOver) return;
            if(Input.GetKeyDown(KeyCode.I)) {
                if(!itemWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                itemWindow.SetActive(!itemWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown(KeyCode.K)) {
                if(!skillWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                skillWindow.SetActive(!skillWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown(KeyCode.S)) {
                if(!statusWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                statusWindow.SetActive(!statusWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
        }
    }
}