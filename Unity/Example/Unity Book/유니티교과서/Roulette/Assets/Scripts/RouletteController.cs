using UnityEngine;

public class RouletteController : MonoBehaviour {

    private float rotSpeed = 0;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            this.rotSpeed = 10;
        }

        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;
	}
}
