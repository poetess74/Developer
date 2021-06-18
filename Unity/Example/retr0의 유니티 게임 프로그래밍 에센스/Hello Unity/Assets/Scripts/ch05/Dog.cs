using UnityEngine;

public class Dog : MonoBehaviour {
    [SerializeField] private string nickName;
    [SerializeField] private float weight;

    private static int count;

    private void Awake() {
        count++;
    }

    private void Start() {
        Bark();
    }

    private void Bark() {
        Debug.LogFormat("All dogs count: {0}", count);
        Debug.LogFormat("{0}: Bark!", nickName);
    }

    public static int getCount() {
        return count;
    }

    public static void ShowAnimalType() {
        Debug.Log("This is dog.");
    }
}
