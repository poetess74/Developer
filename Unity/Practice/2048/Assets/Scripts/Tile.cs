using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	private Text text;
	private Image image;
	private int number = 0;

	private readonly int[] FONT_SIZE = new int[5] { 70, 65, 48, 38, 30 };
	private Dictionary<int, Color32> COLOR_MAP = new Dictionary<int, Color32>() {
		{     2, new Color32(236, 225, 214, 255) },
		{     4, new Color32(235, 220, 194, 255) },
		{     8, new Color32(255, 179, 108, 255) },
		{    16, new Color32(255, 142,  91, 255) },
		{    32, new Color32(255, 108,  76, 255) },
		{    64, new Color32(255,  75,  45, 255) },
		{   128, new Color32(236, 198, 108, 255) },
		{   256, new Color32(236, 198,  91, 255) },
		{   512, new Color32(236, 198,  71, 255) },
		{  1024, new Color32(236, 198,  57, 255) },
		{  2048, new Color32(236, 186,  41, 255) },
		{  4096, new Color32(175, 121, 162, 255) },
		{  8192, new Color32(168,  97, 160, 255) },
		{ 16384, new Color32(161,  81, 157, 255) },
		{ 32768, new Color32( 25,  45,  96, 255) },
		{ 65536, new Color32(  0,   0,   0, 255) }
	};

	public int Number {
		get {
			return number;
		}

		set {
			number = value;

			string numStr = string.Format("{0}", number);
			int strLen = numStr.Length;
			int fontSizeIndex = (strLen - 1 < 5) ? strLen - 1 : 4;
				
			text.text = numStr;
			text.fontSize = FONT_SIZE[fontSizeIndex];

			if (number < 8) {
				text.color = new Color32(62, 56, 51, 255);
			} else {
				text.color = new Color32(255, 255, 255, 255);
			}

			if (number != 0) {
				image.color = COLOR_MAP[number];
			}

			transform.gameObject.SetActive(number != 0);
		}
	}

	void Awake() {
		text = transform.FindChild("Text").GetComponent<Text>();
		image = GetComponent<Image>();
	}

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
	
	}


}
