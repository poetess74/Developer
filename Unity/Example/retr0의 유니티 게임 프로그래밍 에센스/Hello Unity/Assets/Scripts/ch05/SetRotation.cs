using UnityEngine;

public class SetRotation : MonoBehaviour {
    // 쿼터니언 (x, y, z, w)
    // Start is called before the first frame update
    private void Start() {
        Quaternion originalRotation = Quaternion.Euler(new Vector3(45, 0, 0));
        Quaternion plusRotation = Quaternion.Euler(new Vector3(30, 0, 0));
        Quaternion calcRotation = originalRotation * plusRotation;
        transform.rotation = calcRotation;
    }
}
