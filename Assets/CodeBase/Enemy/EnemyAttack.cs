using System;
using System.Linq;
using Hero;
using Infrastructure.Factory;
using Infrastructure.Services;
using Logic;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyAttack : MonoBehaviour {
        public EnemyAnimator enemyAnimator;
        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        public float EffectiveDistance = 0.5f;
        public float Radius = 1f;
        public float damage = 10;
        public float AttackCoolDown = 3;
        private float _attackCoolDown;
        private bool _isAttaking;
        private int _layerMask;
        private Collider[] _hits = new Collider[1];

        private bool _isAttackActive;

        public void SetHeroTransform(Transform heroTransform){
            _heroTransform = heroTransform;
        }

        private void Awake(){
            _layerMask = 1 << LayerMask.NameToLayer("Player");
          
        }

        private void Update(){
            UpdateCoolDown();
            if (CanAttack()){
                StartAttack();
            }
        }

        private void UpdateCoolDown(){
            if (!CoolDownIsUp()){
                _attackCoolDown -= Time.deltaTime;
            }
        }

        private bool CanAttack() => _isAttackActive && !_isAttaking && CoolDownIsUp();

        private bool CoolDownIsUp(){
            return _attackCoolDown <= 0;
        }

        public void StartAttack(){
            transform.LookAt(_heroTransform);
            enemyAnimator.PlayAttack();
            _isAttaking = true;
        }

        public void OnAttack(){
            if (Hit(out Collider hit)){
                PhysicsDebug.DrawDebug(StartPoint(), Radius, 1);
                hit.transform.GetComponent<IHealth>().TakeDamage(damage);
            }
        }

        private bool Hit(out Collider hit){
            int hitCount = Physics.OverlapSphereNonAlloc(StartPoint(), Radius, _hits, _layerMask);
            //вернёт кол-во коллайдеров с которыми пересеклись
            hit = _hits.FirstOrDefault();
            return hitCount > 0;
        }

        private Vector3 StartPoint(){
            return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
                   Vector3.forward * EffectiveDistance;
        }

        public void EndAttack(){
            _attackCoolDown = AttackCoolDown;
            _isAttaking = false;
        }


        public void EnableAttack() => _isAttackActive = true;

        public void DisableAttack() => _isAttackActive = false;
    }
}