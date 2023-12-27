using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
    [RequireComponent(typeof(NavMesh))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAgent : MonoBehaviour {
        public NavMeshAgent navMeshAgent;
        public EnemyAnimator animator;
        public float MinimalVelcity{ get; set; } = 0.1f;

        private void Update(){
            if (ShouldMove()){
                animator.Move(navMeshAgent.velocity.magnitude);
            }
            else{
                animator.StopMoving();
            }
        }

        private bool ShouldMove(){
            return navMeshAgent.velocity.magnitude > MinimalVelcity &&
                   navMeshAgent.remainingDistance > navMeshAgent.radius;
        }
    }
}