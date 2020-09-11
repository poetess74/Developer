using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {
    [SerializeField] private GameObject digitPrintLocation;
    
    [SerializeField] private List<Sprite> smallDigit;
    [SerializeField] private List<Sprite> midDigit;
    [SerializeField] private List<Sprite> bigDigit;

    [SerializeField] private List<GameObject> digits;

    private char size;
    public void Set(int number, char size, bool isAnim) {
        this.size = size;
        if(digits == null) {
            digits = new List<GameObject>();
        } else {
            foreach(GameObject digit in digits) {
                Destroy(digit);
            }
            digits.Clear();
        }

        float xOffset = 0f;
        bool firstDigit = true;
        do {
            var d = number % 10;
            number /= 10;
            var digitGo = Instantiate(digitPrintLocation, transform);
            var digitImage = digitGo.GetComponent<Image>();
            var digitRect = digitGo.GetComponent<RectTransform>();
            switch(char.ToUpper(size)) {
                case'S':
                    digitImage.sprite = smallDigit[d];
                    break;
                case'M':
                    digitImage.sprite = midDigit[d];
                    break;
                case'B':
                    digitImage.sprite = bigDigit[d];
                    break;
                case'\0':
                    break;
                default:
                    Debug.Log("Error: Unknown size parameter. " + size);
                    break;
            }

            digitImage.SetNativeSize();
            digitGo.name = d.ToString();
            digitGo.SetActive(true);
            if(!firstDigit) {
                digitRect.anchoredPosition = new Vector2(xOffset - digitRect.rect.width / 2, 0);
                xOffset -= digitRect.rect.width;
            } else {
                firstDigit = false;
                xOffset -= digitRect.rect.width / 2;
            }

            digits.Add(digitGo);
        } while(number > 0);
    }

    private void Start() {
        digitPrintLocation.SetActive(false);
        Set(0, size, false);
    }
}
