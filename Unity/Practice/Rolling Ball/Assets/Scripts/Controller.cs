using UnityEngine;

public class Controller : MonoBehaviour {

    private void Update () {
        const float maxLimit = 50.0f;
        const float minLimit = 310.0f;

        Vector3 currentRotate = transform.localRotation.eulerAngles;

        if (!GamePlayManager.Destroyed) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                if (currentRotate.x <= maxLimit || currentRotate.x >= minLimit) {
                    transform.Rotate(1, 0, 0);
                } else {
                    GamePlayManager.ResetCTRL = true;
                    transform.Rotate(-GamePlayManager.Control_X, 0, 0);
                }
                GamePlayManager.Control_X = transform.eulerAngles.x;
            } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                if (currentRotate.x <= maxLimit || currentRotate.x >= minLimit) {
                    transform.Rotate(-1, 0, 0);
                } else {
                    GamePlayManager.ResetCTRL = true;
                    transform.Rotate(GamePlayManager.Control_X, 0, 0);
                }
                GamePlayManager.Control_X = transform.eulerAngles.x;
            } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                if (currentRotate.z <= maxLimit || currentRotate.z >= minLimit) {
                    transform.Rotate(0, 0, 1);
                } else {
                    GamePlayManager.ResetCTRL = true;
                    transform.Rotate(0, 0, -GamePlayManager.Control_Z);
                }
                GamePlayManager.Control_Z = transform.eulerAngles.z;
            } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                if (currentRotate.z <= maxLimit || currentRotate.z >= minLimit) {
                    transform.Rotate(0, 0, -1);
                } else {
                    GamePlayManager.ResetCTRL = true;
                    transform.Rotate(0, 0, GamePlayManager.Control_Z);
                }
                GamePlayManager.Control_Z = transform.eulerAngles.z;
            }

            float y = transform.eulerAngles.y;
            transform.Rotate(0, -y, 0);
        } else {
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            float z = transform.eulerAngles.z;

            transform.Rotate(-x, -y, -z); 
            GamePlayManager.Control_X = transform.eulerAngles.x;
            GamePlayManager.Control_Z = transform.eulerAngles.z;
        }
    } 
}
