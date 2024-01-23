using Data;
using Enemy;
using Infrastructure.Factory;
using Infrastructure.Services.Persistent;
using StaticData;
using UnityEngine;

namespace Logic.EnemySpawners {
    public class SpawnPoint : MonoBehaviour, ISaveProgress {
        public MonsterTypeId typeMonster;

        public string _id{ get; set; }
        public bool Slain;
        private IGameFactory _gameFactory;
        private EnemyDeath _enemyDeath;

        public void Construct(IGameFactory factory) => _gameFactory = factory;

        public void LoadProgress(PlayerProgress playerProgress){
            if (playerProgress.KillData.ClearedSpawnerID.Contains(_id)){
                Slain = true;
            }
            else{
                Spawn();
            }
        }

        private void Spawn(){
            GameObject newMonster = _gameFactory.CreateMonster(typeMonster, transform);
            _enemyDeath = newMonster.GetComponent<EnemyDeath>();
            _enemyDeath.Happened += Slay;
        }

        private void Slay(){
            if (_enemyDeath != null)
                _enemyDeath.Happened -= Slay;
            Slain = true;
        }

        public void UpdateProgress(PlayerProgress playerProgress){
            if (Slain){
                playerProgress.KillData.ClearedSpawnerID.Add(_id);
            }
        }
    }
}