using UnityEngine;

public class PointController : MonoBehaviour {
    private PointManager pointManager;
    private MonsterManager monsterManager;
    
    // Start is called before the first frame update
    private void Start() {
        pointManager = FindObjectOfType<PointManager>();
        monsterManager = FindObjectOfType<MonsterManager>();

        pointManager.point = 100;
        Debug.LogFormat("현재 포인트: {0}", pointManager.point);
        
        pointManager.point = -100;
        Debug.LogFormat("현재 포인트: {0}", pointManager.point);
        
        Debug.Log(monsterManager.count);
    }
}
