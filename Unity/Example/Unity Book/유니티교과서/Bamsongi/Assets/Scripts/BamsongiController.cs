using UnityEngine;

public class BamsongiController : MonoBehaviour {

    public void Shoot(Vector3 dir) {
        GetComponent<Rigidbody>().AddForce(dir);
    }

	// Use this for initialization
	private void Start () {
        //Shoot(new Vector3(0, 200, 2000));
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnCollisionEnter (Collision collision) {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }
}
