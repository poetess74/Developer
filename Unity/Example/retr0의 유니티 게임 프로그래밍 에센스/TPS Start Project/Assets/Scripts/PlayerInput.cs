using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool jump { get; private set; }
    
    private string fireButtonName = "Fire1";
    private string jumpButtonName = "Jump";
    private string moveHorizontalAxisName = "Horizontal";
    private string moveVerticalAxisName = "Vertical";
    private string reloadButtonName = "Reload";

    private void Update() {
        if(GameManager.Instance != null
           && GameManager.Instance.isGameover) {
            moveInput = Vector2.zero;
            fire = false;
            reload = false;
            jump = false;
            return;
        }

        moveInput = new Vector2(Input.GetAxis(moveHorizontalAxisName), Input.GetAxis(moveVerticalAxisName));
        if(moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        jump = Input.GetButtonDown(jumpButtonName);
        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}