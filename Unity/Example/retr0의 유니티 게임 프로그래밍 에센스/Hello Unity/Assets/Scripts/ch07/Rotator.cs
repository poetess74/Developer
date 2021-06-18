using UnityEngine;

public class Rotator : MonoBehaviour {
    private float speed = 60f;

    private void Update() {
        Rotate();
    }

    protected virtual void Rotate() {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }

    private class XRotator : Rotator {
        protected override void Rotate() {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
    }

    private class YRotator : Rotator {
        protected override void Rotate() {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    private class ZRotator : Rotator {
        protected override void Rotate() {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
