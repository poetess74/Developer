using UnityEngine;

namespace InGame.Player.UI {
    public class EquipmentInspector : MonoBehaviour {
        private GameObject[] detail;
        private GameObject[] location;

        private void OnEnable() {
            if(detail != null && location != null) return;
            detail = new GameObject[transform.GetChild(3).transform.childCount];
            for(int i = 0; i < detail.Length; i++) {
                detail[i] = transform.GetChild(3).transform.GetChild(i).gameObject;
            }
            location = new GameObject[transform.GetChild(4).transform.childCount];
            for(int i = 0; i < location.Length; i++) {
                location[i] = transform.GetChild(4).transform.GetChild(i).gameObject;
            }
        }

        private void Update() {
            //TODO: Update detail status in equipment and apply equipment in dropbox.
        }
    }
}
