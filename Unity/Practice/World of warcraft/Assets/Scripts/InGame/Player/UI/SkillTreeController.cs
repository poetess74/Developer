using UnityEngine;
using UnityEngine.UI;

public class SkillTreeController : MonoBehaviour {
    [SerializeField] private GameObject skillButton;

    private const float padding = 47;

    private void Start() {
        for(int i = 1; i <= 10; i++) {
            var primary = Instantiate(skillButton, new Vector3(
                 (i - 1) * padding + 51, transform.position.y, transform.position.z
            ), Quaternion.identity, transform);
            primary.gameObject.transform.Find("Title").GetComponent<Text>().text = (i == 10 ? 0 : i).ToString();
            primary.name = "No_" + (i == 10 ? 0 : i);
        }
    }
}
