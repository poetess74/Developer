using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {
    public Image aimPointReticle;
    public Image hitPointReticle;

    public float smoothTime = 10f;
    private RectTransform crossHairRectTransform;

    private Vector3 currentHitPointVelocity;

    private Camera screenCamera;
    private Vector2 targetPoint;

    private void Awake() {
    }

    private void Update() {
    }

    public void SetActiveCrosshair(bool active) {
    }

    public void UpdatePosition(Vector3 worldPoint) {
    }
}