using System.Data;
using Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace QA {
    public class GamePatcher : MonoBehaviour {
        public bool editing { get; private set; }

        private InputField input;
        private EnemySpawner spawner;
        
        private void OnEnable() {
            input = gameObject.GetComponent<InputField>();
            spawner = FindObjectOfType<EnemySpawner>();
            
            input.ActivateInputField();
            editing = true;
        }

        private void EndEdit() {
            editing = false;
            input.text = input.text.Trim();
            if(input.text != "") {
                Patch();
            }
            gameObject.SetActive(false);
            GamePlayManager.instance.interrupt = false;
        }

        private void Patch() {
            switch(input.text) {
                case "KillAllEnemies": spawner.RemoveEnemy(); break;
                case "CreateEnemies": spawner.CreateEnemy(); break;
                default: throw new SyntaxErrorException();
            }
        }
    }
}