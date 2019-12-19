using UnityEngine;

public class TutorialShuttleController : MonoBehaviour {
    private int Signal;
    private bool Done;

    private float Fuel = 18250;

    private Rigidbody rb;
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] Altitude;
    [SerializeField] private AudioClip[] Warn;

    [SerializeField] private AudioClip ClearOfConflicts;
    [SerializeField] private AudioClip Climd;
    [SerializeField] private AudioClip ClimdNow;
    [SerializeField] private AudioClip Descent;
    [SerializeField] private AudioClip DescentNow;
    [SerializeField] private AudioClip DoNotSink;
    [SerializeField] private AudioClip Glideslope;
    [SerializeField] private AudioClip Minimum;
    [SerializeField] private AudioClip PullUp;
    [SerializeField] private AudioClip Retard;
    [SerializeField] private AudioClip Sinkrate;
    [SerializeField] private AudioClip Terrain;
    [SerializeField] private AudioClip TerrainAhead;
    [SerializeField] private AudioClip TooLowFlaps;
    [SerializeField] private AudioClip TooLowGear;
    [SerializeField] private AudioClip TooLowTerrain;
    [SerializeField] private AudioClip Traffic;

    //audioSource.PlayOneShot(AudioClip_Name[]);

    private void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update () {
        GamePlayManager.shuttleAngle = -this.transform.rotation.z;

        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(transform.up * 100000);
            rb.AddForce(transform.forward * 50000);
            GamePlayManager.shuttleFuel -= 0.0001f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(transform.up * -100000);
            rb.AddForce(transform.forward * -50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } 

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.left * 25000);
            GamePlayManager.shuttleFuel -= 0.000025f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.right * 25000);
            GamePlayManager.shuttleFuel -= 0.000025f;
        }

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * 50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * 75000);
            GamePlayManager.shuttleFuel -= 0.00007f;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -Time.deltaTime, 0);
            GamePlayManager.shuttleFuel -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, Time.deltaTime, 0);
            GamePlayManager.shuttleFuel -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(transform.forward * -50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * -70000);
            GamePlayManager.shuttleFuel -= 0.00007f;
        }

        if (rb.velocity.y < 0) {
            if (System.Math.Abs(2500 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[14]);
            } else if (System.Math.Abs(1000 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[13]);
            } else if (System.Math.Abs(500 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[12]);
            } else if (System.Math.Abs(400 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[11]);
            } else if (System.Math.Abs(300 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[10]);
            } else if (System.Math.Abs(200 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[9]);
            } else if (System.Math.Abs(150 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[8]);
            } else if (System.Math.Abs(100 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[7]);
            } else if (System.Math.Abs(70 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[6]);
            } else if (System.Math.Abs(60 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[5]);
            } else if (System.Math.Abs(50 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[4]);
            } else if (System.Math.Abs(40 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[3]);
            } else if (System.Math.Abs(30 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[2]);
            } else if (System.Math.Abs(20 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[1]);
            } else if (System.Math.Abs(10 - GamePlayManager.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[0]);
            }
        }
    }

    private void FixedUpdate () {
        GamePlayManager.shuttleSpeed = rb.velocity.magnitude * 1.94384f;
        GamePlayManager.shuttleAltitude = this.transform.position.y * 3.28084f;
        GamePlayManager.shuttleFuel = this.Fuel * 0.264172f;GamePlayManager.shuttleFuel -= 0.00002f;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else if (Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate () {
        if (GamePlayManager.whoIs == "Shuttle") {
            IndexPath();
        }

        if (Input.GetKeyUp(KeyCode.BackQuote) && GamePlayManager.TutorialShuttleReChat) {
            GamePlayManager.whoIs = "Shuttle";
            GamePlayManager.MessageShow = true;
        }

        if (GamePlayManager.whoIs == "Shuttle") {
            if (GamePlayManager.NextMessage && Done) {
                Done = false;
            }
            Message();
        }


    }

    private void Message () {
        if (!GamePlayManager.TutorialShuttleReChat) {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "Hi! If you hard control in real, practice control in here.";
            }

            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "If you restart or end practice control tutotial press\" ` \"and talk me again.";
            }

            if (GamePlayManager.MessageShow && Signal == 2) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "So let's get start!";
            }

            if (GamePlayManager.MessageShow && Signal == 3) {
                GamePlayManager.MessageTitle = "Tutorial Suttle - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.TutorialShuttleReChat = true;
                    GamePlayManager.NextMessage = false;
                    Signal = 0;
                    Done = false;
                    GamePlayManager.Instance().SwithCamera();
                }
            }
        } else {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "Okay, now the tutorial is over.\n If you restart turorial talk me again.";
            }

            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Tutorial Suttle - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.NextMessage = false;
                    GamePlayManager.TutorialShuttleReChat = false;
                    Signal = 0;
                    Done = false;
                    GamePlayManager.Instance().SwithCamera();
                }
            }
        }
    }

    private void IndexPath () {
        if (GamePlayManager.MessageShow && !GamePlayManager.TutorialShuttleReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 4) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        } else if (GamePlayManager.MessageShow && GamePlayManager.TutorialShuttleReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 4) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        }
    }
}
