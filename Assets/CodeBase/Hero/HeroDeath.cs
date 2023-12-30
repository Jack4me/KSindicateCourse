using System;
using UnityEngine;

namespace Hero {
    [RequireComponent(typeof(HeroDeath))]
    public class HeroDeath : MonoBehaviour {
        public HeroHealth HeroHealth;
        public HeroMove HeroMove;
        public HeroAnimator HeroAnimator;
        public GameObject visualFX;
        public HeroAttack Attack;
        private bool _isDead;

        private void Start(){
            HeroHealth.HealthChanged += HealthChange;
}              
        private void OnDestroy(){
            HeroHealth.HealthChanged -= HealthChange;
}                 

        private void HealthChange(){
            if (HeroHealth.CurrentHp <= 0){
                Die();
            }
        }

        private void Die(){
            _isDead = true;
            HeroMove.enabled = false;
            Attack.enabled = false;
            HeroAnimator.PlayDeath();

            Instantiate(visualFX, transform.position, Quaternion.identity);
        }
    }
}