using UnityEngine;

public class Test : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        Debug.LogFormat("TEST All dogs count: {0}", Dog.getCount());
        Dog.ShowAnimalType();
    }
}
