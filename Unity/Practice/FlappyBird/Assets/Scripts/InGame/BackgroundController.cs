using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private GameObject ground;
    
    private GameObject activeBackground;
    private Vector3 groundOriginPosition;
    private void Start () {
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
        ground.transform.position += Vector3.left * GamePlayManager.scrollSpeed * Time.deltaTime;
        GamePlayManager.dist += GamePlayManager.scrollSpeed;
        if(ground.transform.position.x > GamePlayManager.limitPosition) return;
        ground.transform.position = groundOriginPosition;
    }
}