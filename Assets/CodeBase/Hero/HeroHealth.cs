﻿using System;
using Data;
using Infrastructure.Services.Persistent;
using Logic;
using UnityEngine;


namespace Hero {
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISaveProgress, IHealth{
        private StateHp _playerStateHp;
        public HeroAnimator heroAnimator;
        public event Action HealthChanged;

        public float CurrentHp{
            get => _playerStateHp.currentHp;
            set{
                if ( value  !=_playerStateHp.currentHp){
                    _playerStateHp.currentHp = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        public float MaxHp{
            get => _playerStateHp.maxHp;
            set => _playerStateHp.maxHp = value;
        }

        public void LoadProgress(PlayerProgress playerProgress){
            _playerStateHp = playerProgress.StateHeroHp;
            HealthChanged?.Invoke();

        }

        public void UpdateProgress(PlayerProgress playerProgress){
            playerProgress.StateHeroHp.currentHp = CurrentHp;
            // playerProgress.StateHeroHP.MaxHP = MaxHP;
        }

        public void TakeDamage(float damage){
            Debug.Log("CurrentHP" + CurrentHp);
            
            if (CurrentHp <= 0){
                return;
            }
            CurrentHp -= damage;
            heroAnimator.PlayHit();
        }
    }
}