using UnityEngine;

namespace Player.UI {
    public class GuildSecurity : MonoBehaviour {
        private PlayerInfo info;

        private GameObject login;
        private GameObject logout;
        private GameObject cheatDetect;

        private void Start() {
            info = FindObjectOfType<PlayerInfo>(true);

            login = transform.GetChild(2).gameObject;
            logout = transform.GetChild(3).gameObject;
            cheatDetect = transform.GetChild(4).gameObject;
        }

        private void Update() {
            if(info.isPatched) {
                login.SetActive(false);
                logout.SetActive(false);
                cheatDetect.SetActive(true);
            }
        }
    }
}
