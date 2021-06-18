using UnityEngine;

public class CamFollow : MonoBehaviour {
    [SerializeField] private float delayTime = 0.2f;
    
    private Transform target;
    private Vector3 lastMovingVelocity;
    private Vector3 targetPos;
    private Camera cam;
    private float targetZoomSize = 5f;
    private float lastZoomSpeed;
    
    private const float roundReadyZoomSize = 14.5f;
    private const float readyShotZoomSize = 5f;
    private const float trackingZoomSize = 10f;
    
    public enum State {
        Idle, Ready, Tracking
    }

    private State state {
        set {
            switch(value) {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize;
                    break;
                case State.Ready:
                    targetZoomSize = readyShotZoomSize;
                    break;
                case State.Tracking:
                    targetZoomSize = trackingZoomSize;
                    break;
            }
        }
    }

    private void Awake() {
        cam = GetComponentInChildren<Camera>();
        state = State.Idle;
    }

    private void Move() {
        targetPos = target.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref lastMovingVelocity, delayTime);
    }

    private void Zoom() {
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize, ref lastZoomSpeed, delayTime);
    }

    private void FixedUpdate() {
        if(target == null) return;
        Move();
        Zoom();
    }

    public void Reset() {
        state = State.Idle;
    }

    public void SetTarget(Transform target, State state) {
        this.target = target; 
        this.state = state;
    }
}
