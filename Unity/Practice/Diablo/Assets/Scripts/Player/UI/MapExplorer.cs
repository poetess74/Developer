using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.UI {
    public class MapExplorer : MonoBehaviour, IScrollHandler, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        private GameObject mapCam;
        private MapCamMovement movement;
        
        private Vector3 dragOrigin;
        private Vector3 mapCamOrigin;

        private bool dragging;
        private bool mousePointerEntered;

        private void OnEnable() {
            movement = FindObjectOfType<MapCamMovement>();
            mapCam = movement.gameObject;
        }

        private void Update() {
            if(Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() && mousePointerEntered) {
                dragOrigin = Input.mousePosition;
                mapCamOrigin = mapCam.transform.position;

                dragging = true;
            }

            if(Input.GetMouseButtonUp(0)) {
                dragging = false;
                movement.ResetPos(false, false);
            }

            if(dragging) {
                Vector3 offset = dragOrigin - Input.mousePosition;
                float scaleUnit = (mapCam.GetComponent<Camera>().orthographicSize * 2) /
                                  GetComponent<RectTransform>().rect.height;
                mapCam.transform.position = mapCamOrigin + new Vector3(offset.x * scaleUnit, 0, offset.y * scaleUnit);
            }
        }
        
        private void FixedUpdate() {
            if(!movement.constRotate) {
                mapCam.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
        
        private void OnDisable() {
            if(movement == null) return;
            movement.ResetPos(true, true);
        }

        public void OnScroll(PointerEventData eventData) {
            movement.manualControl = true;
            mapCam.GetComponent<Camera>().orthographicSize = Mathf.Clamp(
                mapCam.GetComponent<Camera>().orthographicSize + eventData.scrollDelta.y * 0.1f, 5f, 1000f
            );
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(eventData.button == PointerEventData.InputButton.Right) {
                movement.ResetPos(false, true);
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            mousePointerEntered = true;
        }

        public void OnPointerExit(PointerEventData eventData) {
            mousePointerEntered = false;
        }
    }
}