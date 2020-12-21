using UnityEngine;

public class CircleProgressCreater : MonoBehaviour {
    [SerializeField] private GameObject circleLoader;

    private void Start() {
        Instantiate(circleLoader, transform.position, Quaternion.identity, transform);
    }
    private void Update() {
    }
}