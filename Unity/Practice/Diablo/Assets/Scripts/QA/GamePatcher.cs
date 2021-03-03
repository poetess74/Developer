using System;
using System.Data;
using Enemy;
using Player;
using UnityEditor;
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
                        } else if(command[1] == "spawn") {
                            spawner.CreateEnemy("Test", "Human");
                        } else if(command[1] == "harm" && command[2] == "true") {
                            foreach(var enemy in spawner.enemies) {
                                enemy.GetComponent<EnemyMovement>().isHarmPlayer = true;
                            }
                        } else if(command[1] == "harm" && command[2] == "false") {
                            foreach(var enemy in spawner.enemies) {
                                enemy.GetComponent<EnemyMovement>().isHarmPlayer = false;
                            }
                        } else {
                           throw new SyntaxErrorException("patcher: command not found: " + input.text); 
                        }
                        break;
                    case "player":
                        if(command[1] == "kill") {
                            damage.Damaged(int.MaxValue, false, gameObject);
                        } else if(command[1] == "respawn") {
                            if(!GamePlayManager.instance.isGameOver) {
                                Debug.LogWarningFormat("patcher: {0} has not effected. player doesn't killed!", input.text);
                                return;
                            }
                            damage.Respawn();
                        } else {
                           throw new SyntaxErrorException("patcher: command not found: " + input.text); 
                        }
                        break;
                    case "exit": return;
                    case "quit": EditorApplication.isPlaying = false; return;
                    default: throw new SyntaxErrorException("patcher: command not found: " + input.text); 
                }
                Debug.LogFormat("patcher: {0} has been applied.", input.text);
            } catch(Exception e) {
                Debug.LogError(e.Message);
            }
        }
    }
}