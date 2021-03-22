using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Intro {
    public class BackgroundChanger : MonoBehaviour {
        [SerializeField] private Texture wallPaper;
        [SerializeField] private Texture video;

        private RawImage image;
        private VideoPlayer player;
        private GameObject guide;

        private bool nowPlaying;
        private bool runningCoroutine;

        private void Start() {
            image = GetComponent<RawImage>();
            player = FindObjectOfType<VideoPlayer>();
            guide = transform.parent.GetChild(1).gameObject;
        }

        private void Update() {
            image.texture = !nowPlaying ? wallPaper : video;
            guide.SetActive(!nowPlaying);

            if(!nowPlaying) {
                if(runningCoroutine) return;
                StartCoroutine("waitPlayStory");
            } else {
                player.Play();
                player.loopPointReached += EndReached;
            }
        }

        private IEnumerator waitPlayStory() {
            runningCoroutine = true;
            yield return new WaitForSeconds(10f);
            nowPlaying = true;
            player.Prepare();
            runningCoroutine = false;
        }

        private void EndReached(VideoPlayer videoPlayer) {
            nowPlaying = false;
            videoPlayer.Stop();
        }
    }
}
