using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public GameObject[] backgrounds;

    private GameObject activeBackground;
    private Vector3 originPosition;

    private void Start () {
        foreach (var background in this.backgrounds) {
            background.SetActive(false);
        }
        int activeIndex = Random.Range(0, this.backgrounds.Length);
        this.activeBackground = backgrounds[activeIndex];
        this.activeBackground.SetActive(true);
        this.originPosition = this.activeBackground.transform.position;
    }
	
	void Update () {
        this.activeBackground.transform.position += Vector3.down * GamePlayManager.scrollSpeed * Time.deltaTime;

        GamePlayManager.AddDistance(0.01f);
        GamePlayManager.AddScore(1);

        if (this.activeBackground.transform.position.y <= -10.2f) {
            this.activeBackground.transform.position = this.originPosition;
        }
	}
}
