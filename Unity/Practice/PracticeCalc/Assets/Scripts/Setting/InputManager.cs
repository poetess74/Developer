using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Setting {
    public class InputManager : MonoBehaviour {
        [SerializeField] private AlertDialogController revertAlert;
        [SerializeField] private AlertDialogController deleteStatusAlert;
        [SerializeField] private AlertDialogController deleteSettingAlert;
        [SerializeField] private AlertDialogController deleteAllAlert;

        private CreateQuestionCount questionCount;

        private string dangerZoneSubTitle;

        private void Start() {
            questionCount = FindObjectOfType<CreateQuestionCount>();
        }

        public void RevertAllChanges() {
            revertAlert.SetAlertDialog("계속 진행할 경우 데이터가 유실될 수 있음",
                "계속 진행할 경우 변경사항이 반영되지 않으며 이전 설정을 유지하게 됩니다. \n \n(WRN-3845)",
                "변경사항 폐기", "취소", false, true, Color.red, Color.clear);
        }

        private void Delete(string type) {
            switch(type) {
                case "status":
                    deleteStatusAlert.SetAlertDialog("계속 진행할 경우 데이터가 유실될 수 있음",
                        dangerZoneSubTitle,
                        "삭제", "취소", false, true, Color.red, Color.clear);
                    break;
                case "setting":
                    deleteSettingAlert.SetAlertDialog("계속 진행할 경우 데이터가 유실될 수 있음",
                        dangerZoneSubTitle,
                        "삭제", "취소", false, true, Color.red, Color.clear);
                    break;
                case "all":
                    deleteAllAlert.SetAlertDialog("계속 진행할 경우 데이터가 유실될 수 있음",
                        dangerZoneSubTitle,
                        "삭제", "취소", false, true, Color.red, Color.clear);
                    break;
            }
        }

        public void DeleteStatus() {
            dangerZoneSubTitle = "계속 진행할 경우 모든 통계가 삭제됩니다. 이 작업은 되돌릴 수 없습니다. \n \n(WRN-1731)";
            Delete("status");
        }

        public void DeleteSetting() {
            dangerZoneSubTitle = "계속 진행할 경우 모든 설정이 재설정됩니다. 이 작업은 되돌릴 수 없습니다. \n \n(WRN-1732)";
            Delete("setting");
        }

        public void DeleteAll() {
            dangerZoneSubTitle = "계속 진행할 경우 모든 설정이 재설정되고 통계가 삭제됩니다. 이 작업은 되돌릴 수 없습니다. \n \n(WRN-1733)";
            Delete("all");
        }

        public void DeleteStatusAlert(bool autoExecute) {
            GameManager.instance.Reset();

            if(autoExecute) return;
            SceneManager.LoadScene(0);
        }

        public void DeleteSettingAlert(bool autoExecute) {
            GameManager.instance.ResetSetting();

            if(autoExecute) return;
            SceneManager.LoadScene(0);
        }

        public void DeleteAllAlert() {
            DeleteStatusAlert(true);
            DeleteSettingAlert(true);

            SceneManager.LoadScene(0);
        }

        public void NegativeButton() {
            if(revertAlert != null) revertAlert.SetActiveAlertDialog(false);
            if(deleteStatusAlert != null) deleteStatusAlert.SetActiveAlertDialog(false);
            if(deleteSettingAlert != null) deleteSettingAlert.SetActiveAlertDialog(false);
            if(deleteAllAlert != null) deleteAllAlert.SetActiveAlertDialog(false);
        }

        public void SaveChanges() {
            if(questionCount.random.isOn) {
                GameManager.instance.providedQuestionCount = Random.Range(20, 100);
            }

            GameManager.instance.Save();
            SceneManager.LoadScene(0);
        }

        public void RevertAllChangesForce() {
            SceneManager.LoadScene(0);
        }
    }
}
