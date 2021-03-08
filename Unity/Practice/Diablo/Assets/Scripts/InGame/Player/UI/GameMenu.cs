using UnityEditor;
using UnityEngine;

namespace InGame.Player.UI {
    public class GameMenu : MonoBehaviour {
        private GameObject guildWindow;

        private void Start() {
            guildWindow = transform.parent.parent.GetChild(4).gameObject;
        }
        
        private void Help() {
            throw new System.NotImplementedException();
        }

        private void GameSettings() {
            throw new System.NotImplementedException();
        }

        private void GraphicSettings() {
            throw new System.NotImplementedException();
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
