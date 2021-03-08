using UnityEditor;
using UnityEngine;

namespace InGame.Player.UI {
    public class GameMenu : MonoBehaviour {
        [SerializeField] private GameObject helpWindow;
        [SerializeField] private GameObject gameSettingWindow;
        [SerializeField] private GameObject graphicSettingWindow;

        private GameObject guildWindow;

        private void Start() {
            guildWindow = transform.parent.parent.GetChild(4).gameObject;
        }
        
        private void Help() {
            helpWindow.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }

        private void GameSettings() {
            gameSettingWindow.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }

        private void GraphicSettings() {
            graphicSettingWindow.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }

        private void GuildWindowOpen() {
            guildWindow.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }

        private void Logout() {
            throw new System.NotImplementedException();
        }

        private void Exit() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit(0);
            #endif
        }
    }
}
