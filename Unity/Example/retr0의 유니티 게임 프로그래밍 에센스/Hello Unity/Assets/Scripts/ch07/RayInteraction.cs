using UnityEngine;

public class RayInteraction : MonoBehaviour {
    [SerializeField] private LayerMask filter;
    [SerializeField] private float distance = 100f;
    
    private Camera playerCam;
    private Transform moveTarget;
    private float targetDistance;
    
    // Start is called before the first frame update
    private void Start() {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    private void Update() {
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Vector3 rayDir = playerCam.transform.forward;

        Ray ray = new Ray(rayOrigin, rayDir);
        
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, distance, filter)) {
                GameObject hitTarget = hit.collider.gameObject;
                hitTarget.GetComponent<Renderer>().material.color = Color.red;

                moveTarget = hitTarget.transform;
                targetDistance = hit.distance;
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            if(moveTarget != null) {
                moveTarget.GetComponent<Renderer>().material.color = Color.white;
            }
            moveTarget = null;
        }

        if(moveTarget != null) {
            moveTarget.position = ray.origin + ray.direction * targetDistance;
        }
    }
}
