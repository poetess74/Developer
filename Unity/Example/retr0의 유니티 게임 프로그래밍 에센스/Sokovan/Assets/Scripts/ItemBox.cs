using UnityEngine;

public class ItemBox : MonoBehaviour {
    public bool isCollision;
    [SerializeField] private Color touchColor;
    
    private Material material;
    private Color originColor;
    
    // Start is called before the first frame update
    private void Start() {
        material = GetComponent<Renderer>().material;
        originColor = material.color;
    }

    //트리거인 콜라이더와 충돌할 때 자동으로 실행
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Finish")) {
            material.color = touchColor;
            isCollision = true;
        }
    }
    
    //트리거인 콜라이더와 붙어있을 때
    private void OnTriggerStay(Collider other) {
        if(other.tag.Equals("Finish")) {
            material.color = touchColor;
            isCollision = true;
        }
    }

    // 붙어있다가 분리될 때
    private void OnTriggerExit(Collider other) {
        if(other.tag.Equals("Finish")) {
            material.color = originColor;
            isCollision = false;
        }
    }
}
