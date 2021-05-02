using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using InGame.Enemy;
using InGame.Player;
using InGame.Player.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QA {
    public class GamePatcher : MonoBehaviour {
        public bool editing { get; private set; }
        public bool enablePatch;

        private List<string> commands;

        private InputField input;
        private EnemySpawner spawner;
        private PlayerDamage damage;
        private PlayerEXP exp;
        private PlayerInfo info;

        private int index;
        
        private void OnEnable() {
            if(commands == null) commands = new List<string>();

            info = FindObjectOfType<PlayerInfo>(true);
            input = gameObject.GetComponent<InputField>();
            spawner = FindObjectOfType<EnemySpawner>();
            damage = FindObjectOfType<PlayerDamage>();
            exp = FindObjectOfType<PlayerEXP>();

            StartCoroutine(SelectInputField());
            editing = true;
        }

        private void Update() {
            if(commands.Count == 0) return;
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                index = (index - 1 < 0) ? commands.Count - 1 : index - 1;
                input.text = commands[index];
            }

            if(Input.GetKeyDown(KeyCode.DownArrow)) {
                index = (index + 1 > commands.Count - 1) ? 0 : index + 1;
                input.text = commands[index];
            }
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
                        } else if(command[1] == "immune" && command[2] == "true") {
                            foreach(var enemy in spawner.enemies) {
                                enemy.GetComponent<EnemyDamage>().immune = true;
                            }
                        } else if(command[1] == "immune" && command[2] == "false") {
                            foreach(var enemy in spawner.enemies) {
                                enemy.GetComponent<EnemyDamage>().immune = false;
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
                                Debug.LogWarningFormat("patcher: {0} did not effected. player doesn't killed!", input.text);
                                return;
                            }
                            damage.Respawn();
                        } else if(command[1] == "exp" && command[2] == "add") {
                            exp.AddPlayerEXP(float.Parse(command[3]));
                        } else if(command[1] == "immune" && command[2] == "true") {
                            damage.GetComponent<PlayerDamage>().immune = true;
                        } else if(command[1] == "immune" && command[2] == "false") {
                            damage.GetComponent<PlayerDamage>().immune = false;
                        } else {
                           throw new SyntaxErrorException("patcher: command not found: " + input.text); 
                        }
                        break;
                    case "exit": return;
                    case "scene":
                        if(command[1] == "load") {
                            SceneManager.LoadScene(command[2]);
                        } else if(command[1] == "reload") {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        } else {
                           throw new SyntaxErrorException("patcher: command not found: " + input.text);
                        }
                        break;
                    case "quit": EditorApplication.isPlaying = false; return;
                    default: throw new SyntaxErrorException("patcher: command not found: " + command[0]);
                }
                Debug.LogFormat("patcher: {0} has been applied.", input.text);
                if(!info.isPatched) {
                    Debug.LogWarning(
                        "patcher: PID and Guild are currently disabled! If you want recover these problem, you should restart Diablo. "
                    );
                }
                info.isPatched = true;
            } catch(Exception e) {
                Debug.LogError(e.Message);
            }
            commands.Add(input.text);
        }

        private IEnumerator SelectInputField() {
            yield return new WaitForEndOfFrame();
            input.ActivateInputField();
        }
    }
}
