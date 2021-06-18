using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket_Space : MonoBehaviour {

    private const float rcsThrust = 5f;
    private const float mainThrust = 1000f;

    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	private void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void Update () {
        Thrust();
        Rotate();
	}

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Earth":
                SceneManager.LoadScene("Earth");
                break;
            case "Untagged":
                print("OK"); //HACK Remove OK
                break;
            default:
                print("GameOver!");
                break;
        }
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            UserInfo.power -= 0.002f;
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            UserInfo.power -= 0.002f;
            rigidBody.AddRelativeForce(Vector3.down * mainThrust);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    private void Rotate() {
        rigidBody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationThisFrame);
            UserInfo.power -= 0.001f;
        } else if (Input.GetKey(KeyCode.D)) {
            UserInfo.power -= 0.001f;
            transform.Rotate(Vector3.back * rotationThisFrame);
            UserInfo.power -= 0.001f;
        } else if (Input.GetKey(KeyCode.W)) {
            UserInfo.power -= 0.001f;
            transform.Rotate(Vector3.right * rotationThisFrame);
            UserInfo.power -= 0.001f;
        } else if (Input.GetKey(KeyCode.S)) {
            UserInfo.power -= 0.001f;
            transform.Rotate(Vector3.left * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;
    }
}
