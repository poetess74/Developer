using UnityEngine;

public class BackgroundController : MonoBehaviour {
    [SerializeField] private GameObject[] backgrounds;

    private GameObject activeBackground;
    private Vector3 originPosition;

    private void Start () {
        foreach (var background in backgrounds) {
            background.SetActive(false);
        }
        int activeIndex = Random.Range(0, backgrounds.Length);
        activeBackground = backgrounds[activeIndex];
        activeBackground.SetActive(true);
        originPosition = activeBackground.transform.position;
    }
	
	private void Update () {
        activeBackground.transform.position += Vector3.down * GamePlayManager.scrollSpeed * Time.deltaTime;

        GamePlayManager.AddDistance(0.01f);
        GamePlayManager.AddScore(1);

        if (activeBackground.transform.position.y <= -10.2f) {
            activeBackground.transform.position = originPosition;
        }
	}
}
