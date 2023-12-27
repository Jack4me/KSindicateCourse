using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
    public class AgentMoveToPlayer : Follow {
        public NavMeshAgent navMeshAgent;
        private Transform _heroTransform;
        private const float MinimalDistance = 0.1f;
        private IGameFactory _gameFactory;

        private void Start(){
            _gameFactory = AllServices.Container.GetService<IGameFactory>();
            if (_gameFactory.HeroGameObject != null){
                InitializeHeroTransform();
            }
            else{
                _gameFactory.HeroCreated += HeroCreated;
            }
        }

        private void Update(){
            if (Initialize() && DistanceToPlayer()){
                navMeshAgent.destination = _heroTransform.position;
            }
        }

        private bool Initialize() => _heroTransform != null;

        private void HeroCreated() => InitializeHeroTransform();

        private void InitializeHeroTransform() => _heroTransform = _gameFactory.HeroGameObject.transform;

        private bool DistanceToPlayer() => 
            Vector3.Distance(navMeshAgent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}