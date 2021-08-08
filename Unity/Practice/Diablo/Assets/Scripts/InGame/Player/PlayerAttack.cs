using System;
using System.Collections.Generic;
using InGame.Enemy;
using InGame.Player.UI;
using Other;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace InGame.Player {
    public class PlayerAttack : MonoBehaviour {
        public List<GameObject> target { get; private set; }
        
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private LayerMask enemyFilter;
        [SerializeField] private PlayerSkillSelector skill;
        
        private PlayerStatus status;
        private PlayerInput input;
        private Animator animator;

        private void Start() {
            status = GetComponent<PlayerStatus>();
            input = GetComponent<PlayerInput>();
            target = new List<GameObject>();
            animator = GetComponent<Animator>();
        }

        private void Update() {
            if(GamePlayManager.instance.isGameOver || GamePlayManager.instance.hardInterrupt || GamePlayManager.instance.softInterrupt) return;
            if(Input.GetKeyDown(KeyVerification(KeyCode.Alpha1, KeyCode.Joystick1Button1, 0))) {
                if(skill.skill[0].GetComponent<Dropdown>().value == 0) {
                    GetEnemy(false);
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 1f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength, false, gameObject);
                    }
                } else if(skill.skill[0].GetComponent<Dropdown>().value == 1) {
                    bool result = Random.Range(0, 2) == 0;
                    GetEnemy(!result);
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 2f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength * 2, result, gameObject);
                    }
                } else {
                    GetEnemy(true);
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 5f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength * 5, true, gameObject);
                    }
                }
            }
            if(Input.GetKeyDown(KeyVerification(KeyCode.Alpha2, KeyCode.Joystick1Button2, 1)) && status.playerLV >= 3) {
                if(skill.skill[1].GetComponent<Dropdown>().value == 0) {
                    if(!Utility.resourceResource(status.manaPointCNT, 7f) || status.healthPointCNT.Equals(status.healthPoint)) return;

                    status.manaPointCNT -= 7f;
                    status.healthPointCNT += Utility.remainResourceProcess(status.healthPoint, status.healthPointCNT, 10f);
                }
            }
        }

        private void LateUpdate() {
            for(int i = 0; i < target.Count; i++) {
                if(target[i].GetComponent<EnemyDamage>().enemyCNTHP <= 0f) {
                    target.Remove(target[i]);
                }
            }
        }

        private void GetEnemy(bool multiple) {
            target.Clear();
            if(multiple) {
                var hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, maxDistance, enemyFilter);
                foreach(RaycastHit hit in hits) {
                    if(hit.transform.GetComponent<EnemyDamage>().enemyCNTHP <= 0f) continue;

                    target.Add(hit.transform.gameObject);
                }
                StartCoroutine(Utility.animPlayOneShot(
                    animator, "Female Sword Attack 3", "Attack", "AtkAnim", 2, true
                ));
            } else {
                var startPos = new Vector3(transform.position.x, 0.8f, transform.position.z);
                if(Physics.Raycast(startPos, transform.forward, out RaycastHit hit, maxDistance, enemyFilter)) {
                    if(hit.transform.GetComponent<EnemyDamage>().enemyCNTHP <= 0f) return;
                    target.Add(hit.transform.gameObject);
                }
                StartCoroutine(Utility.animPlayOneShot(
                    animator, "Female Sword Attack 1", "Attack", "AtkAnim", 0, true
                ));
            }
        }

        private KeyCode KeyVerification(KeyCode defaultKeyCode, KeyCode alternativeKeyCode, int index) {
            try {
                var input = (KeyCode) Enum.Parse(typeof(KeyCode), skill.trigger[index].GetComponent<InputField>().text);
                skill.trigger[index].GetComponent<InputField>().textComponent.color = Color.black;
                if(this.input.axisController) {
                    if(input.ToString().Contains("Joystick")) {
                        return input;
                    } else {
                        skill.trigger[index].GetComponent<InputField>().text = alternativeKeyCode.ToString();
                        return alternativeKeyCode;
                    }
                } else {
                    if(input.ToString().Contains("Joystick")) {
                        skill.trigger[index].GetComponent<InputField>().text = defaultKeyCode.ToString();
                        return defaultKeyCode;
                    } else {
                        return input;
                    }
                }
            } catch(ArgumentException) {
                skill.trigger[index].GetComponent<InputField>().textComponent.color = Color.red;
                return input.axisController ? alternativeKeyCode : defaultKeyCode;
            }
        }
    }
}
