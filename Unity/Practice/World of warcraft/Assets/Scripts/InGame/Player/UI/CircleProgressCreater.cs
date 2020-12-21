using UnityEngine;

public class CircleProgressCreater : MonoBehaviour {
    [SerializeField] private GameObject circleLoader;

    public static CircleProgressCreater circleProgressCreater;
    
    private void Awake() {
        circleProgressCreater = this;
    }
    
    public void createProgress() {
        Instantiate(circleLoader, transform.position, Quaternion.identity, transform);
    }
}