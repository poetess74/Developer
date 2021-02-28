using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.UI {
    public class MapExplorer : MonoBehaviour, IDragHandler, IEndDragHandler, IScrollHandler, IPointerClickHandler {
        private GameObject mapCam;
        private MapCamMovement movement;

        private void OnEnable() {
            movement = FindObjectOfType<MapCamMovement>();
            mapCam = movement.gameObject;
        }

        private void Update() {
            if(!movement.constRotate) {
                mapCam.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
        
        private void OnDisable() {
            if(movement == null) return;
            movement.ResetPos(true, true);
        }

        public void OnDrag(PointerEventData eventData) {
            //BUG: Doesn't match Screen and world point.
            if(eventData.button == PointerEventData.InputButton.Left) {
                movement.manualControl = true;
                Vector3 convertedInput = Camera.main.ScreenToWorldPoint(new Vector3(
                        eventData.position.x, Input.mousePosition.z, eventData.position.y 
                ));
                mapCam.transform.position = new Vector3(convertedInput.x, mapCam.transform.position.y, convertedInput.z);
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            movement.ResetPos(false, false);
        }

        public void OnScroll(PointerEventData eventData) {
            movement.manualControl = true;
            mapCam.transform.position = new Vector3(
                mapCam.transform.position.x, Mathf.Clamp(
                    mapCam.transform.position.y + eventData.scrollDelta.y, 5f, 1000f
                ), mapCam.transform.position.z
            );
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(eventData.button == PointerEventData.InputButton.Right) {
                movement.ResetPos(false, true);
            }
        }
    }
}