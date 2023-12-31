using System;
using Data;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using Logic;
using Services.Input;
using UnityEngine;

namespace Hero {
    [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
    public class HeroAttack : MonoBehaviour, ISaveProgress {
        public HeroAnimator HeroAnimator;
        public CharacterController CharacterController;

        private IInputService _inputService;
        private static int _layerMask;
        private Collider[] _hits = new Collider[3];
        private float _radius;
        private HeroStats _heroStats;

        private void Awake(){
            _inputService = AllServices.Container.GetService<IInputService>();
            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        }

        private void Update(){
            if (_inputService.IsAttackButtonUp() && !HeroAnimator.IsAttacking){
                HeroAnimator.PlayAttack();
            }
        }

        public void OnAttack(){
            for (int i = 0; i < Hit(); i++){
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_heroStats.Damage);
            }
        }

        public void LoadProgress(PlayerProgress playerProgress){
            _heroStats = playerProgress.HeroStats;
        }

        private int Hit(){
            Debug.Log(StartPoint());
            return Physics.OverlapSphereNonAlloc(StartPoint() + transform.forward,_heroStats.DamageRadius,_hits, _layerMask);
        }

        private Vector3 StartPoint(){
            return new Vector3(transform.position.x, CharacterController.center.y / 2, transform.position.z);
        }

        public void UpdateProgress(PlayerProgress playerProgress){
            
        }
    }
}