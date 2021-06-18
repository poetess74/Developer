using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InGame.UI {
    public class InfoHyperlinks : MonoBehaviour, IPointerClickHandler {
        private TextMeshProUGUI text;

        private void OnEnable() {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void OnPointerClick(PointerEventData eventData) {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, Camera.main);
            if(linkIndex == -1) return;

            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
