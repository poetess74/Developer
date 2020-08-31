using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private GameObject ground;

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float limitPosition;
    
    private GameObject activeBackground;
    private Vector3 groundOriginPosition;
    private void Start () {
        GamePlayManager.scrollSpeed = scrollSpeed;
        GamePlayManager.limitPosition = limitPosition;
        foreach(var background in backgrounds) {
            background.SetActive(false);
        }

        int activeIndex = Random.Range(0, backgrounds.Count);
        activeBackground = backgrounds[activeIndex];
        activeBackground.SetActive(true);
        groundOriginPosition = ground.transform.position;
    }
	
    private void Update () {
        if(GamePlayManager.isGameOver) return;
        ground.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        GamePlayManager.dist += scrollSpeed;
        if(ground.transform.position.x > limitPosition) return;
        ground.transform.position = groundOriginPosition;
    }
}