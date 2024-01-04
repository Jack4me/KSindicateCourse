using System;
using Infrastructure.Factory;
using UnityEngine;

namespace Enemy {
    public class LootSpawner : MonoBehaviour {
        public EnemyDeath EnemyDeath;

        //сервис получаем в момент создания врага
        private IGameFactory _gameFactory;

        private void Start(){
            EnemyDeath.Happened += SpawnLoot;
        }

        public void Constract(IGameFactory factory){
            _gameFactory = factory;
        }

        private void SpawnLoot(){
            GameObject loot = _gameFactory.CreateLoot();
            loot.transform.position = transform.position;
        }
    }
}