using System;
using UnityEngine;

namespace Hero {
    public class ActorUI : MonoBehaviour {
        public HpBar hpBar;
        private HeroHealth _heroHealth;

        public void SetHp(HeroHealth Health){
            _heroHealth = Health;
            _heroHealth.HealthChange += UpdateHpBar;
        }

        public void UpdateHpBar(){
            Debug.Log("ACTOR UI");
            hpBar.SetValue(_heroHealth.CurrentHp, _heroHealth.MaxHp);
        }

        private void OnDestroy(){
            _heroHealth.HealthChange -= UpdateHpBar;
        }
    }
}