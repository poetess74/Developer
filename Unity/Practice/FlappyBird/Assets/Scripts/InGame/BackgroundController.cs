using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private List<GameObject> grounds;

    [SerializeField] private float scrollSpeed;
    [SerializeField] private List<float> limitPosition;
    
    private GameObject activeBackground;
    private List<Vector3> groundOriginPosition;
    private void Start () {
        GamePlayManager.scrollSpeed = scrollSpeed;
        GamePlayManager.limitPosition = limitPosition[0];
        foreach(var background in backgrounds) {
            background.SetActive(false);
        }

        int activeIndex = Random.Range(0, backgrounds.Count);
        activeBackground = backgrounds[activeIndex];
        activeBackground.SetActive(true);
        
        groundOriginPosition = new List<Vector3>();
        
        for(int i = 0; i < grounds.Count; i++) {
            groundOriginPosition.Add(grounds[i].transform.position);
        }
    }
	
    private void Update () {
        if(GamePlayManager.IsGameOver) {
            grounds[0].transform.position = new Vector3(-14.4f, -4.83f, 0);
            grounds[1].transform.position = new Vector3(14.4f, -4.83f, 0);
            return;
        }
        grounds[0].transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        grounds[1].transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if(grounds[0].transform.position.x <= limitPosition[1]) {
            grounds[0].transform.position = groundOriginPosition[1];
        }
        if(grounds[1].transform.position.x <= limitPosition[1]) {
            grounds[1].transform.position = groundOriginPosition[1];
        }
    }
}