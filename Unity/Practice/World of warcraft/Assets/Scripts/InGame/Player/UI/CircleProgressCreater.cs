using UnityEngine;

public class CircleProgressCreater : MonoBehaviour {
    [SerializeField] private GameObject circleLoader;

    private void Start() {
        Instantiate(circleLoader, Vector3.zero, Quaternion.identity, transform);
    }
    private void Update() {
    }
}