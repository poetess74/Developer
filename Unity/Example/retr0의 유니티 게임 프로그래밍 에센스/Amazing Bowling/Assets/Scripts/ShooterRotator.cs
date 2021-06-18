using UnityEngine;

public class ShooterRotator : MonoBehaviour {
    [SerializeField] private float verticalRotateAmount = 360f;
    [SerializeField] private float horizontalRotateAmount = 360f;
    
    private enum RotateState {
        Idle, Vertical, Horizontal, Ready
    }
    private RotateState status = RotateState.Idle;
    
    private void OnEnable() {
        transform.rotation = Quaternion.identity;
        status = RotateState.Idle;
        GetComponent<BallShooter>().enabled = false;
    }

    private void Update() {
        switch(status) {
            case RotateState.Idle:
                if(Input.GetButtonDown("Fire1")) {
                    status = RotateState.Horizontal;
                }
                break;
            case RotateState.Horizontal:
                if(Input.GetButton("Fire1")) {
                    transform.Rotate(new Vector3(0, horizontalRotateAmount * Time.deltaTime, 0));
                } else if(Input.GetButtonUp("Fire1")) {
                    status = RotateState.Vertical;
                }
                break;
            case RotateState.Vertical:
                if(Input.GetButton("Fire1")) {
                    transform.Rotate(new Vector3(-verticalRotateAmount * Time.deltaTime, 0, 0));
                } else if(Input.GetButtonUp("Fire1")) {
                    status = RotateState.Ready;
                }
                break;
            case RotateState.Ready:
                GetComponent<BallShooter>().enabled = true;
                break;
        }
    }
}
