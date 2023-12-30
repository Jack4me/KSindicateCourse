using System;
using Logic;
using UnityEngine;
    
namespace Enemy {
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth {
        public EnemyAnimator EnemyAnimator;
        [SerializeField] private float _currentHp;
        [SerializeField] private float _maxHp;

        public float CurrentHp{
            get{ return _currentHp; }
            set{ _currentHp = value; }
        }

        public float MaxHp{
            get{ return _maxHp; }
            set{ _maxHp = value; }
        }

        public event Action HealthChanged;

        public void TakeDamage(float damage){
            _currentHp -= damage;
            EnemyAnimator.PlayHit();
            
            HealthChanged?.Invoke();
        }
    }
}