using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool isGameOver;
    [SerializeField] private ItemBox[] itemBoxes;
    [SerializeField] private GameObject winUI;
    
    // Start is called before the first frame update
    private void Start() {
        isGameOver = false;
        winUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }
        
        if (isGameOver) return;
        
        int count = 0;
        foreach(var item in itemBoxes) {
            if(item.isCollision) count++;
        }

        if(count == itemBoxes.Length) {
            isGameOver = true;
            winUI.SetActive(true);
        }
    }
}
