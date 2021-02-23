using UnityEngine;

namespace Player.UI {
    public class PlayerInspector : MonoBehaviour {
        
        private GameObject menuWindow;
        private GameObject itemWindow;
        private GameObject skillWindow;
        private GameObject statusWindow;
        private GameObject guildWindow;

        private void Start() {
            menuWindow = transform.GetChild(0).gameObject;
            itemWindow = transform.GetChild(1).gameObject;
            skillWindow = transform.GetChild(2).gameObject;
            statusWindow = transform.GetChild(3).gameObject;
            guildWindow = transform.GetChild(4).gameObject;
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(!menuWindow.activeSelf && GamePlayManager.instance.interrupt) {
                    CloseAllWindow();
                    return;
                }
                menuWindow.SetActive(!menuWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown(KeyCode.G)) {
                if(!guildWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                guildWindow.SetActive(!guildWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }

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

        private void CloseAllWindow() {
            menuWindow.SetActive(false);
            guildWindow.SetActive(false);
            itemWindow.SetActive(false);
            skillWindow.SetActive(false);
            statusWindow.SetActive(false);
            GamePlayManager.instance.interrupt = false;
        }
    }
}