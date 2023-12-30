using System;
using System.Collections;
using UnityEngine;

namespace Enemy {
    public class EnemyDeath : MonoBehaviour {
        public EnemyHealth EnemyHealth;
        public EnemyAnimator EnemyAnimator;
        public event Action Happened;

        public GameObject DeathFX;

        private void Start(){
            EnemyHealth.HealthChanged += EnemyDie;
        }

        private void OnDestroy(){
            EnemyHealth.HealthChanged -= EnemyDie;
        }

        private void EnemyDie(){
            if (EnemyHealth.CurrentHp <= 0){
                Die();
            }
        }

        private void Die(){
            EnemyHealth.HealthChanged -= EnemyDie;
            EnemyAnimator.PlayDeath();
            SpawnDeathFX();
            StartCoroutine(DestroyGameObj());
            Happened?.Invoke();
        }

        private void SpawnDeathFX(){
            Instantiate(DeathFX, transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyGameObj(){
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}