using UnityEngine;
using UnityEngine.UI;

namespace InGame.Player.UI {
    public class WarningHPController : MonoBehaviour {
        private PlayerStatus status;
        private RawImage image;
        private Animation anim;

        private void Start() {
            status = FindObjectOfType<PlayerStatus>();
            image = GetComponent<RawImage>();
            anim = GetComponent<Animation>();
        }

        private void Update() {
            if(status.healthPointCNT / status.healthPoint * 100 > 20f) {
                anim.enabled = false;
                image.color = UpdateAlpha(0f);
            } else if(status.healthPointCNT / status.healthPoint * 100 > 0f) {
                anim.enabled = true;
                anim.Play("WarningHP");
            } else {
                anim.Stop();
                anim.Rewind();
                anim.enabled = false;
                image.color = UpdateAlpha(1f);
            }
        }

        private Color UpdateAlpha(float alpha) {
            Color tempColor = image.color;
            tempColor.a = alpha;
            return tempColor;
        }
    }
}
