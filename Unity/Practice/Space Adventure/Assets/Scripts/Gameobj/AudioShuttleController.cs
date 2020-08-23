using UnityEngine;

public class AudioShuttleController : MonoBehaviour {
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

    private void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update () {
        if (GamePlayManager.shuttleAltitude > 0) {
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
}
