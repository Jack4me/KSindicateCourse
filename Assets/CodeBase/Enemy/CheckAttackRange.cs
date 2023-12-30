using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(EnemyAttack))]
    public class CheckAttackRange : MonoBehaviour{
        public TriggerObserver triggerObserver;
        public EnemyAttack enemyAttack;

        private void Start(){
            triggerObserver.TriggerEnter += OnTriggerEnter;
            triggerObserver.TriggerExit  += OnTriggerExit;
        }

        private void OnTriggerEnter(Collider Obj){
            enemyAttack.EnableAttack();
        }

        private void OnTriggerExit(Collider Obj){
            enemyAttack.DisableAttack();
            
        }
    }
}