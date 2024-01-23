﻿using System;
using Data;
using Enemy;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using StaticData;
using UnityEngine;

namespace Logic {
    public class EnemySpawner : MonoBehaviour, ISaveProgress {
        public MonsterTypeId typeMonster;

        public string _id;
        public bool Slain;
        private IGameFactory _factory;
        private EnemyDeath _enemyDeath;

        private void Awake(){
            _id = GetComponent<UniqueID>().ID;
            _factory = AllServices.Container.GetService<IGameFactory>();
        }

        public void LoadProgress(PlayerProgress playerProgress){
            if (playerProgress.KillData.ClearedSpawnerID.Contains(_id)){
                Slain = true;

            }
            else{
                Spawn();

            }
        }

        private void Spawn(){
            GameObject newMonster = _factory.CreateMonster(typeMonster, transform);
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