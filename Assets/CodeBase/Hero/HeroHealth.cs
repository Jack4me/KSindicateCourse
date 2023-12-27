using System;
using Data;
using UnityEngine;


namespace Hero {
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISaveProgress {
        private StateHp _playerStateHp;
        public HeroAnimator heroAnimator;
        public Action HealthChange;

        public float CurrentHp{
            get => _playerStateHp.currentHp;
            set{
                if ( value  !=_playerStateHp.currentHp){
                    _playerStateHp.currentHp = value;
                    HealthChange?.Invoke();
                }
            }
        }

        public float MaxHp{
            get => _playerStateHp.maxHp;
        }

        public void LoadProgress(PlayerProgress PlayerProgress){
            _playerStateHp = PlayerProgress.stateHeroHp;
            HealthChange?.Invoke();

            Debug.Log("MAaaaaaaaaX HP" + _playerStateHp.maxHp);
        }

        public void UpdateProgress(PlayerProgress PlayerProgress){
            PlayerProgress.stateHeroHp.currentHp = CurrentHp;
            // playerProgress.StateHeroHP.MaxHP = MaxHP;
        }

        public void TakeDamage(float Damage){
            Debug.Log("Take Damage");
            Debug.Log("CurrentHP" + CurrentHp);
            Debug.Log("MAX HP" + MaxHp);
            if (CurrentHp <= 0){
                return;
            }
            CurrentHp -= Damage;
            heroAnimator.PlayHit();
            Debug.Log("CurrentHP" + CurrentHp);
        }
    }
}