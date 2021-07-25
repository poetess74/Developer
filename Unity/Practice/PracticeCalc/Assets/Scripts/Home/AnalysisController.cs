using UnityEngine;
using UnityEngine.UI;

namespace Home {
    public class AnalysisController : MonoBehaviour {
        private void Start() {
            gameObject.GetComponent<Text>().text = $"총 {GameManager.instance.triedQuestion:##,###}문항을 시도하였으며\n그 중 {GameManager.instance.performance:F2}%가 정답입니다. ";
        }
    }
}
