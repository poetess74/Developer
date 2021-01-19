using UnityEngine;
using UnityEngine.EventSystems;

public class EventTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public void OnBeginDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }
}
