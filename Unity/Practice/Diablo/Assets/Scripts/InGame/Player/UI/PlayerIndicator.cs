using UnityEngine;
using UnityEngine.EventSystems;

namespace InGame.Player.UI {
    public class PlayerIndicator : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler, IPointerExitHandler {
        public void OnPointerEnter(PointerEventData eventData) {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData) {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        
        public void OnPointerExit(PointerEventData eventData) {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
