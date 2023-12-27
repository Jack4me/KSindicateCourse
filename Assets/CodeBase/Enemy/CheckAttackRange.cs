using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour{
        public TriggerObserver triggerObserver;
        public Attack attack;

        private void Start(){
            triggerObserver.TriggerEnter += OnTriggerEnter;
            triggerObserver.TriggerExit  += OnTriggerExit;
        }

        private void OnTriggerEnter(Collider Obj){
            attack.EnableAttack();
        }

        private void OnTriggerExit(Collider Obj){
            attack.DisableAttack();
            
        }
    }
}