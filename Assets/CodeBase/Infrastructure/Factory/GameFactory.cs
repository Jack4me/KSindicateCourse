using System;
using System.Collections.Generic;
using Hero;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.Persistent;
using UnityEngine;

namespace Infrastructure.Factory {
    public class GameFactory : IGameFactory {
        private readonly IInstantiateProvider _instantiate;
        public List<ISaveProgressReader> ProgressReaders{ get; } = new List<ISaveProgressReader>();
        public List<ISaveProgress> ProgressWriters{ get; } = new List<ISaveProgress>();
        public event Action HeroCreated;

        public GameObject HeroGameObject{ get; set; }

        public GameFactory(IInstantiateProvider Instantiate){
            _instantiate = Instantiate;
        }

        public GameObject CreateHero(GameObject At){
            HeroGameObject = InstantiateRegister(AssetPath.HeroPath, At.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public GameObject CreateHud(){
            return InstantiateRegister(AssetPath.HUDPath);
        }

        public void CleanUp(){
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegister(string Path, Vector3 Position){
           // GameObject gameObject = _instantiate.Instantiate(path, position);
            GameObject gameObject = _instantiate.Instantiate(Path);

            RegisterProgressWatcher(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegister(string path){
            GameObject gameObject = _instantiate.Instantiate(path);
            RegisterProgressWatcher(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatcher(GameObject hero){
            foreach (ISaveProgressReader progressReader in hero.GetComponentsInChildren<ISaveProgressReader>()){
                Register(progressReader);
            }
        }

        private void Register(ISaveProgressReader progressReader){
            if (progressReader is ISaveProgress progressWriter){
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}