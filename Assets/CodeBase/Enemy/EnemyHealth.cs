using System;
using Logic;
using UnityEngine;
    
namespace Enemy {
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth {
        public EnemyAnimator EnemyAnimator;
        [SerializeField] private float _currentHp;
        [SerializeField] private float _maxHp;

        public event Action HealthChanged;
        public float CurrentHp{
            get{ return _currentHp; }
            set{ _currentHp = value; }
        }

        public float MaxHp{
            get{ return _maxHp; }
            set{ _maxHp = value; }
        }


        public void TakeDamage(float damage){
            Debug.Log("HITTTT");
            _currentHp -= damage;
            EnemyAnimator.PlayHit();
            Debug.Log(_currentHp);
            HealthChanged?.Invoke();
        }
    }
}