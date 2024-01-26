using System;
using UI;
using UI.Elements;
using UnityEngine;

namespace Hero {
    public class ActionUI : MonoBehaviour {
        public HpBar hpBar;
        private HeroHealth _heroHealth;

        public void SetHp(HeroHealth Health){
            _heroHealth = Health;
            _heroHealth.HealthChanged += UpdateHpBar;
        }

        public void UpdateHpBar(){
            hpBar.SetValue(_heroHealth.CurrentHp, _heroHealth.MaxHp);
        }

        private void OnDestroy(){
            _heroHealth.HealthChanged -= UpdateHpBar;
        }
    }
}