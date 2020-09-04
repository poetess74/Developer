using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public GameObject _digitTemplate;
    public List<Sprite> _digitSprites;

    private List<GameObject> _digits;

    public void Set(int num)
    {
        if (_digits == null)
        {
            _digits = new List<GameObject>();
        }
        else
        {
            foreach (var digit in _digits)
                Destroy(digit);

            _digits.Clear();
        }

        float xoffset = 0f;
        bool firstDigit = true;

        do
        {
            var d = num % 10;
            num /= 10;

            var digitGo = Instantiate(_digitTemplate, transform);
            var digitImage = digitGo.GetComponent<Image>();
            var digitRect = digitGo.GetComponent<RectTransform>();

            digitImage.sprite = _digitSprites[d];
            digitImage.SetNativeSize();

            digitGo.name = d.ToString();
            digitGo.SetActive(true);

            if (!firstDigit)
            {
                digitRect.anchoredPosition = new Vector2(xoffset - digitRect.rect.width / 2, 0);
                xoffset -= digitRect.rect.width;
            }
            else
            {
                firstDigit = false;
                xoffset -= digitRect.rect.width / 2;
            }

            _digits.Add(digitGo);
        } while (num > 0);
    }

    private void Start()
    {
        _digitTemplate.SetActive(false);
        Set(0);
    }
}
