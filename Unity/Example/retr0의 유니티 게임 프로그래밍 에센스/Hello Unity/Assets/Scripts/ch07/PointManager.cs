using UnityEngine;

public class PointManager : MonoBehaviour {
    //int a = point; GET
    //point = 100; SET
    public int point {
        get {
            Debug.Log(m_score);
            return m_score;
        }
        
        set {
            m_score = value < 0 ? 0 : value;
        }
    }
    private int m_score;
}
