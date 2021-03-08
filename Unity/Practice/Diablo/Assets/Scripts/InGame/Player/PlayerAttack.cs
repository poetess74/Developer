using System.Collections.Generic;
using InGame.Enemy;
using InGame.Player.UI;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Player {
    public class PlayerAttack : MonoBehaviour {
        public List<GameObject> target { get; private set; }
        
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private LayerMask enemyFilter;
        [SerializeField] private PlayerSkillSelector skill;
        
        private PlayerStatus status;
        private Animator animator;
        
        private void Start() {
            status = GetComponent<PlayerStatus>();
            target = new List<GameObject>();
            animator = GetComponent<Animator>();
        }

        private void Update() {
            if(GamePlayManager.instance.isGameOver || GamePlayManager.instance.interrupt) return;
            if(Input.GetButtonDown(skill.trigger[0].GetComponent<InputField>().text)) {
                if(skill.skill[0].GetComponent<Dropdown>().value == 0) {
                    GetEnemyHealth();
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 1f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength, false, gameObject);
                    }
                } else if(skill.skill[0].GetComponent<Dropdown>().value == 1) {
                    GetEnemyHealth();
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 2f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength * 2, Random.Range(0, 2) == 1, gameObject);
                    }
                } else {
                    GetEnemyHealth();
                    if(target.Count == 0) return;
                    
                    status.manaPointCNT += Utility.remainResourceProcess(status.manaPoint, status.manaPointCNT, 5f);
                    
                    foreach(GameObject enemy in target) {
                        enemy.GetComponent<IDamageable>().Damaged(status.strength * 5, true, gameObject);
                    }
                }
            }
            if(Input.GetButtonDown(skill.trigger[1].GetComponent<InputField>().text) && GamePlayManager.instance.stageLV >= 3) {
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

        private void GetEnemyHealth() {
            target.Clear();
            
            var hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, maxDistance, enemyFilter);
            foreach(RaycastHit hit in hits) {
                if(hit.transform.GetComponent<EnemyDamage>().enemyCNTHP <= 0f) continue;
                
                target.Add(hit.transform.gameObject);
            }
        }
    }
}
