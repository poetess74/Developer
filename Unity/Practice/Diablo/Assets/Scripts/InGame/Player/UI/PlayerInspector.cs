using System;
using QA;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Player.UI {
    public class PlayerInspector : MonoBehaviour {
        private GameObject menuWindow;
        private GameObject itemWindow;
        private GameObject skillWindow;
        private GameObject statusWindow;
        private GameObject guildWindow;
        private GameObject mapWindow;
        private GameObject equipWindow;
        private GameObject patcher;

        private GameObject detail;
        private GameObject hotKey;

        private void Start() {
            menuWindow = transform.GetChild(0).gameObject;
            itemWindow = transform.GetChild(1).gameObject;
            skillWindow = transform.GetChild(2).gameObject;
            statusWindow = transform.GetChild(3).gameObject;
            guildWindow = transform.GetChild(4).gameObject;
            mapWindow = transform.GetChild(5).gameObject;
            equipWindow = transform.GetChild(6).gameObject;
            patcher = transform.GetChild(7).gameObject;

            detail = transform.parent.GetChild(3).gameObject;
            hotKey = detail.transform.GetChild(2).GetChild(2).gameObject;
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

            if(detail.transform.GetChild(2).gameObject.activeSelf && GamePlayManager.instance.interrupt) return;
            if(patcher.GetComponent<GamePatcher>().editing) return;
            
            if(Input.GetKeyDown(KeyCode.Slash) && Debug.isDebugBuild && patcher.GetComponent<GamePatcher>().enablePatch) {
                if(!patcher.activeSelf && GamePlayManager.instance.interrupt) return;
                patcher.SetActive(!patcher.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            } else if(Input.GetKeyDown(KeyCode.Slash) && Debug.isDebugBuild && !patcher.GetComponent<GamePatcher>().enablePatch) {
                Debug.LogError("patcher: To use this feature, you should first activate it.");
            }

            if(GamePlayManager.instance.isGameOver) return;

            WindowController(itemWindow, KeyCode.I, 0);
            WindowController(skillWindow, KeyCode.K, 1);
            WindowController(statusWindow, KeyCode.S, 2);
            WindowController(guildWindow, KeyCode.G, 3);
            WindowController(equipWindow, KeyCode.E, 4);
            WindowController(mapWindow, KeyCode.M, 5);
        }

        private void CloseAllWindow() {
            menuWindow.SetActive(false);
            guildWindow.SetActive(false);
            itemWindow.SetActive(false);
            skillWindow.SetActive(false);
            statusWindow.SetActive(false);
            mapWindow.SetActive(false);
            equipWindow.SetActive(false);
            patcher.SetActive(false);
            for(int i = 0; i < detail.transform.childCount; i++) {
                detail.transform.GetChild(i).gameObject.SetActive(false);
            }
            GamePlayManager.instance.interrupt = false;
        }

        private void WindowController(GameObject window, KeyCode defaultKeyCode, int index) {
            try {
                var input = (KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(index).GetChild(1).GetComponent<InputField>().text);
                hotKey.transform.GetChild(index).GetChild(1).GetComponent<InputField>().textComponent.color = Color.black;
                hotKey.transform.GetChild(index).GetChild(2).gameObject.SetActive(false);

                if(Input.GetKeyDown(input)) {
                    if(!window.activeSelf && GamePlayManager.instance.interrupt) return;
                    window.SetActive(!window.activeSelf);
                    GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
                }
            } catch(ArgumentException) {
                hotKey.transform.GetChild(index).GetChild(1).GetComponent<InputField>().textComponent.color = Color.red;
                hotKey.transform.GetChild(index).GetChild(2).gameObject.SetActive(true);

                if(Input.GetKeyDown(defaultKeyCode)) {
                    if(!window.activeSelf && GamePlayManager.instance.interrupt) return;
                    window.SetActive(!window.activeSelf);
                    GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
                }
            }
        }
    }
}
