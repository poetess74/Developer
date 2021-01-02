using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool isGameOver;
    [SerializeField] private ItemBox[] itemBoxes;
    
    // Start is called before the first frame update
    private void Start() {
        isGameOver = false;
    }

    // Update is called once per frame
    private void Update() {
        if (isGameOver) return;
        
        int count = 0;
        foreach(var item in itemBoxes) {
            if(item.isCollision) count++;
        }

        if(count == itemBoxes.Length) {
            isGameOver = true;
            Debug.Log("Player Win!");
        }
    }
}
