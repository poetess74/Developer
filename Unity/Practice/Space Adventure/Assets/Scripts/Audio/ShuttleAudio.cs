using UnityEngine;

public class ShuttleAudio : MonoBehaviour {
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
        if (ShuttleDB.shuttleAltitude > 0) {
            if (System.Math.Abs(2500 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[14]);
            } else if (System.Math.Abs(1000 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[13]);
            } else if (System.Math.Abs(500 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[12]);
            } else if (System.Math.Abs(400 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[11]);
            } else if (System.Math.Abs(300 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[10]);
            } else if (System.Math.Abs(200 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[9]);
            } else if (System.Math.Abs(150 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[8]);
            } else if (System.Math.Abs(100 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[7]);
            } else if (System.Math.Abs(70 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[6]);
            } else if (System.Math.Abs(60 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[5]);
            } else if (System.Math.Abs(50 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[4]);
            } else if (System.Math.Abs(40 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[3]);
            } else if (System.Math.Abs(30 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[2]);
            } else if (System.Math.Abs(20 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[1]);
            } else if (System.Math.Abs(10 - ShuttleDB.shuttleAltitude) < float.Epsilon) {
                audioSource.PlayOneShot(Altitude[0]);
            }
        }
    }
}
