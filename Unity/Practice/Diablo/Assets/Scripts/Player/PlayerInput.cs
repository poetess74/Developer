using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector2 moveInput { get; private set; }

        private string moveHorizontalAxis = "Horizontal";
        private string moveVerticalAxis = "Vertical";

        // Update is called once per frame
        private void Update() {
            moveInput = new Vector2(Input.GetAxis(moveHorizontalAxis), Input.GetAxis(moveVerticalAxis));
            if(moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;
        }
    }
}
