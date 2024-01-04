using System;
using Data;
using UnityEngine;

namespace Enemy {
    public class LootPiece : MonoBehaviour {
        private LootData _loot;
        private bool _picked;

        public void Initialize(LootData loot){
            _loot = loot;
        }

        private void OnTriggerEnter(Collider other){
            PickUp();
        }

        private void PickUp(){
            if (_picked){
                return;
            } 
            _picked = true;
        }
    }
}