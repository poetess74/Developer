using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    [SerializeField]
    public GameObject panelGO;

    private Coroutine hideCoroutine = null;
    private GameObject target = null;

    private void Awake()
    {
        instance = this;
    }

    //public void OnTogglePanelButtonPress()
    //{
    //    var panel = panelGO.GetComponent<Panel>();

    //    if (panel.isShown)
    //        iTween.MoveTo(panelGO, new Vector3(transform.position.x, -35, 0), 1f);
    //    else
    //        iTween.MoveTo(panelGO, new Vector3(transform.position.x, 35, 0), 1f);

    //    panel.isShown = !panel.isShown;
    //}

    public void ShowPanel(GameObject target)
    {
        if (this.target == target)
            return;

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
            hideCoroutine = null;
        }

        this.target = target;

        panelGO.GetComponentInChildren<UnityEngine.UI.Text>().text = target.name;
        iTween.MoveTo(panelGO, new Vector3(transform.position.x, 35, 0), 1f);

        hideCoroutine = StartCoroutine(HidePanel());
    }

    private IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(3f);
        iTween.MoveTo(panelGO, new Vector3(transform.position.x, -35, 0), 1f);

        hideCoroutine = null;
        this.target = null;
    }
}
