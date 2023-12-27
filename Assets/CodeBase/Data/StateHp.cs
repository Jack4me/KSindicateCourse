using System;
using UnityEngine;

namespace Data {
    [Serializable]
    public class StateHp {
        public float currentHp;
        public float maxHp;

        private void Awake(){
            Debug.Log(currentHp + " CURRENT");
            Debug.Log(maxHp + "MAX");
        }

        public void ResetHp(){
            currentHp = maxHp;
        }
    }
}