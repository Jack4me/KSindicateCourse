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

      

        public void SetHeroTransform(Transform heroTransform){
            _heroTransform = heroTransform;
        }

        private void Update(){
            if ( DistanceToPlayer()){
                navMeshAgent.destination = _heroTransform.position;
            }
        }




        private bool DistanceToPlayer() => 
            Vector3.Distance(navMeshAgent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}