using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                Controller.instance.ShowPanel(gameObject);
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }
}

