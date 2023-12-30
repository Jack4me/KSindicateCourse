using System;
using Data;
using Enemy;
using Infrastructure.Services.Persistent;
using StaticData;
using UnityEngine;

namespace Logic {
    public class EnemySpawner : MonoBehaviour, ISaveProgress {
        public MostersEmun typeMonster;

        private string _id;
        private bool _slain;

        private void Awake(){
            _id = GetComponent<UniqueID>().ID;
        }

        public void LoadProgress(PlayerProgress playerProgress){
            if (playerProgress.KillData.ClearedSpawnerID.Contains(_id)){
                _slain = true;
            }
            else{
                Spawn();
            }
        }

        private void Spawn(){
            Debug.Log("SPAAAWN");
        }

        public void UpdateProgress(PlayerProgress playerProgress){
            if (_slain){
                playerProgress.KillData.ClearedSpawnerID.Add(_id);
            }
        }
    }
}