using UnityEngine;

public class TargetingController : MonoBehaviour {
    [SerializeField] private GameObject targetBox;
    
    private Ray radar;
    private RaycastHit target;
    private float maximumTargetDistance = 15f;

    private void LateUpdate() {
        radar = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(radar.origin, radar.direction* maximumTargetDistance, Color.red, 0.3f);
        if(Physics.Raycast(radar.origin, radar.direction, out target, maximumTargetDistance)) {
            if(Input.GetMouseButtonDown(0)) {
                if(target.transform.CompareTag("Player") || target.transform.CompareTag("Ground")) {
                    targetBox.SetActive(false);
                    GamePlayManager.TargetLV = 0;
                    return;
                }
                GamePlayManager.TargetName = target.transform.name;
                
                //TODO: Remove below hard coded code updated source.
                GamePlayManager.TargetLV = 1;
                
                GamePlayManager.target = target.transform.gameObject;
                targetBox.SetActive(true);
            }
        }

        if (GamePlayManager.target == null) return;
        if(Vector3.Distance(GamePlayManager.target.transform.position, transform.position) >= 20f) {
            targetBox.SetActive(false);
            GamePlayManager.TargetLV = 0;
        }
    }
}
