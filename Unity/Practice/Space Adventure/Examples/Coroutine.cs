using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Range(1, 60)]
    public float interval = 1f;

    private MeshRenderer _renderer;
    private Coroutine _changerCoroutine;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _changerCoroutine = StartCoroutine(WaitAndChangeColor());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_changerCoroutine != null)
            {
                StopCoroutine(_changerCoroutine);
                _changerCoroutine = null;
            }
            else
            {
                _changerCoroutine = StartCoroutine(WaitAndChangeColor());
            }
        }
    }

    IEnumerator WaitAndChangeColor()
    {
        yield return new WaitForSeconds(interval);

        var mat = _renderer.material;

        mat.color = new Color(Random.Range(0f, 1f),
                              Random.Range(0f, 1f),
                              Random.Range(0f, 1f), 1f);

        _changerCoroutine = StartCoroutine(WaitAndChangeColor());
    }
}