using System;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;

namespace Enemy {
    public class RotateToHero : Follow {
        private IGameFactory _gameFactory;
        private Transform _heroTransform;
        private Vector3 _positionToLook;
        [SerializeField] private float speed;

        private void Start(){
            _gameFactory = AllServices.Container.GetService<IGameFactory>();
            if (HeroExist()){
                InitializeHeroTransform();
            }
            else{
                _gameFactory.HeroCreated += InitializeHeroTransform;
            }
        }

        private void Update(){
            if (InitializeHero()){
                RotateTowardToHero();
            }
        }

        private void RotateTowardToHero(){
            UpdatePositionToLookAt();
            transform.rotation = SmootheRotation(transform.rotation, _positionToLook);
        }

        private Quaternion SmootheRotation(Quaternion Rotation, Vector3 PositionToLook) =>
            Quaternion.Lerp(Rotation, TargetRotation(PositionToLook), SpeedFactor());

        private float SpeedFactor() => speed * Time.deltaTime;

        private Quaternion TargetRotation(Vector3 PositionToLook) => Quaternion.LookRotation(PositionToLook);

        private void UpdatePositionToLookAt(){
            Vector3 lookAt = _heroTransform.position - transform.position;
            _positionToLook = new Vector3(lookAt.x, transform.position.y, lookAt.z);
        }

        private void InitializeHeroTransform(){
            _heroTransform = _gameFactory.HeroGameObject.transform;
        }

        private bool HeroExist() => _gameFactory.HeroGameObject != null;

        private bool InitializeHero() => _heroTransform != null;
    }
}