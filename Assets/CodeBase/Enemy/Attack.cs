using System;
using System.Linq;
using Hero;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

namespace Enemy {
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour {
        public EnemyAnimator enemyAnimator;
        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        public float AttackCoolDown = 3;
        private float _attackCoolDown;
        private bool _isAttaking;
        private int _layerMask;
        public float radius = 1f;
        private Collider[] _hits = new Collider[1];
        public float effectiveDistance = 0.5f;
        private bool _isAttackActive;
        [SerializeField] private float damage = 10;

        private void Awake(){
            _layerMask = 1 << LayerMask.NameToLayer("Player");
            _gameFactory = AllServices.Container.GetService<IGameFactory>();
            _gameFactory.HeroCreated += OnHeroCreated;
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

        private bool CoolDownIsUp() => _attackCoolDown <= 0;

        public void StartAttack(){
            transform.LookAt(_heroTransform);
            enemyAnimator.PlayAttack();
            _isAttaking = true;
        }

        public void OnAttack(){
            if (Hit(out Collider hit)){
                PhysicsDebug.DrawDebug(StartPoint(), radius, 1);
                hit.transform.GetComponent<HeroHealth>().TakeDamage(damage);
            }
        }

        private bool Hit(out Collider Hit){
            int hitCount = Physics.OverlapSphereNonAlloc(StartPoint(), radius, _hits, _layerMask);
            //вернёт кол-во коллайдеров с которыми пересеклись
            Hit = _hits.FirstOrDefault();
            return hitCount > 0;
        }

        private Vector3 StartPoint(){
            return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
                   Vector3.forward * effectiveDistance;
        }

        public void EndAttack(){
            _attackCoolDown = AttackCoolDown;
            _isAttaking = false;
        }

        private void OnHeroCreated() => _heroTransform = _gameFactory.HeroGameObject.transform;

        public void EnableAttack() => _isAttackActive = true;

        public void DisableAttack() => _isAttackActive = false;
    }
}