using UnityEngine;

public class MenuController : MonoBehaviour {
    [SerializeField] private GameObject menuBox;
    private bool openMenu;
    
    private void MenuOpen() {
        openMenu = !openMenu;
        menuBox.SetActive(openMenu);
    }
}
