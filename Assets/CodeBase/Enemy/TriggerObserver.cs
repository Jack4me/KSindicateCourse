using System;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour {
        public event Action<Collider> TriggerEnter;

        public event Action<Collider> TriggerExit;

        private void OnTriggerEnter(Collider Obj){
            TriggerEnter?.Invoke(Obj);
            Debug.Log(Obj.name);
        }

        private void OnTriggerExit(Collider Obj){
            TriggerExit?.Invoke(Obj);
        }
    }
}