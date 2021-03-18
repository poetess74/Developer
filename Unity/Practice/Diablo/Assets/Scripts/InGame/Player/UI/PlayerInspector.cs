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
            
            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(0).GetChild(1).GetComponent<InputField>().text))) {
                if(!itemWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                itemWindow.SetActive(!itemWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(1).GetChild(1).GetComponent<InputField>().text))) {
                if(!skillWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                skillWindow.SetActive(!skillWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(2).GetChild(1).GetComponent<InputField>().text))) {
                if(!statusWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                statusWindow.SetActive(!statusWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
            
            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(5).GetChild(1).GetComponent<InputField>().text))) {
                if(!mapWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                mapWindow.SetActive(!mapWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }

            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(4).GetChild(1).GetComponent<InputField>().text))) {
                if(!equipWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                equipWindow.SetActive(!equipWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }

            if(Input.GetKeyDown((KeyCode) Enum.Parse(typeof(KeyCode), hotKey.transform.GetChild(3).GetChild(1).GetComponent<InputField>().text))) {
                if(!guildWindow.activeSelf && GamePlayManager.instance.interrupt) return;
                guildWindow.SetActive(!guildWindow.activeSelf);
                GamePlayManager.instance.interrupt = !GamePlayManager.instance.interrupt;
            }
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
    }
}
