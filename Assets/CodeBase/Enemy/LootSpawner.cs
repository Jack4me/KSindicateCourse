using System;
using Data;
using Infrastructure.Factory;
using Infrastructure.Services.Randomizer;
using UnityEngine;

namespace Enemy {
    public class LootSpawner : MonoBehaviour {
        public EnemyDeath EnemyDeath;

        //сервис получаем в момент создания врага
        private IGameFactory _gameFactory;
        private int _lootMin;
        private int _lootMax;
        private IRandomService _random;

        private void Start(){
            EnemyDeath.Happened += SpawnLoot;
        }

        public void Constract(IGameFactory factory, IRandomService randomService){
            _gameFactory = factory;
            _random = randomService;

        }

        private void SpawnLoot(){
            LootPiece loot = _gameFactory.CreateLoot();
            loot.transform.position = transform.position;
            var lootData = new Loot(){ Value = _random.Next(_lootMin, _lootMax) };
        }

        public void SetLoot(int min, int max){
            _lootMin = min;
            _lootMax = max;
        }
    }
}