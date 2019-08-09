﻿using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
    GameObject timerText;
    GameObject pointText;
    GameObject generator;

    private float time = 30f;
    private int point;

	// Use this for initialization
	private void Start () {
        this.generator = GameObject.Find("ItemGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }
	
	// Update is called once per frame
	private void Update () {
        this.time -= Time.deltaTime;
        if (this.time < 0) {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000f, 0, 0);
        } else if (0 <= this.time && this.time < 5) {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        } else if (5 <= this.time && this.time < 12) {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        } else if (12 <= this.time && this.time < 23) {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        } else if (23 <= this.time && this.time < 30) {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1f, -0.03f, 2);
        }
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }

    public void GetApple() {
        this.point += 100;
    }

    public void GetBomb() {
        this.point /= 2;
    }
}
