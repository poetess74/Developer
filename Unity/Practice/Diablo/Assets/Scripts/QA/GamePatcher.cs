using System;
using System.Data;
using Enemy;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace QA {
    public class GamePatcher : MonoBehaviour {
        public bool editing { get; private set; }

        private InputField input;
        private EnemySpawner spawner;
        private PlayerDamage damage;
        
        private void OnEnable() {
            input = gameObject.GetComponent<InputField>();
            spawner = FindObjectOfType<EnemySpawner>();
            damage = FindObjectOfType<PlayerDamage>();
            
            input.ActivateInputField();
            editing = true;
        }

        private void EndEdit() {
            editing = false;
            input.text = input.text.Trim();
            if(input.text != "") {
                Patch();
            }

            input.text = "";
            gameObject.SetActive(false);
            GamePlayManager.instance.interrupt = false;
        }

        private void Patch() {
            string[] command = input.text.Split(' ');

            try {
                switch(command[0]) {
                    case"enemy":
                        if(command[1] == "kill" && command[2] == "all") {
                            spawner.RemoveEnemy();
                        } else if(command[1] == "create") {
                            spawner.CreateEnemy();
                        }
                        break;
                    case "player":
                        if(command[1] == "kill") {
                            damage.Damaged(int.MaxValue, false, gameObject);
                        }
                        if(command[1] == "respawn") {
                            damage.Respawn();
                        }
                        break;
                    case "exit": return;
                    default: throw new SyntaxErrorException("'" + input.text + "' command not found");
                }
            } catch(Exception e) {
                Debug.LogError(e.Message);
            }
        }
    }
}