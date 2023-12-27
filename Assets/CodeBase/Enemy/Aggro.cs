using System;
using System.Collections;
using UnityEngine;

namespace Enemy {
    public class Aggro : MonoBehaviour {
        public TriggerObserver triggerObserver;
        public Follow follow;
        public float сooldown;
        private Coroutine _aggrpCoroutine;
        private bool _hasAggroTarget;

        private void Start(){
            triggerObserver.TriggerEnter += TriggerEnter;
            triggerObserver.TriggerExit += TriggerExit;
            SwitchFollowOff();
            
        }

        private void TriggerExit(Collider Obj){
            if (_hasAggroTarget){
                _hasAggroTarget = false;
                _aggrpCoroutine = StartCoroutine(SwitchFolliwOffAFterCouldDown());
            }
        }

        private void TriggerEnter(Collider Obj){
            if (!_hasAggroTarget){
                _hasAggroTarget = true;
                StopAggroCoroutine();
                SwitchFollowOn();
            }
        }

        private IEnumerator SwitchFolliwOffAFterCouldDown(){
            yield return new WaitForSeconds(сooldown);
            SwitchFollowOff();
        }

        private void StopAggroCoroutine(){
            if (_aggrpCoroutine != null){
                StopCoroutine(_aggrpCoroutine);
                _aggrpCoroutine = null;
            }
        }

        private void SwitchFollowOn() => follow.enabled = true;

        private void SwitchFollowOff() => follow.enabled = false;
    }
}