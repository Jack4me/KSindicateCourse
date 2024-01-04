using System.Collections.Generic;
using Enemy;
using Hero;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.Persistent;
using StaticData;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Infrastructure.Factory {
    public class GameFactory : IGameFactory {
        private readonly IInstantiateProvider _instantiate;
        private readonly IStaticDataService _staticData;
        public List<ISaveProgressReader> ProgressReaders{ get; } = new List<ISaveProgressReader>();
        public List<ISaveProgress> ProgressWriters{ get; } = new List<ISaveProgress>();

        public GameObject HeroGameObject{ get; set; }

        public GameFactory(IInstantiateProvider instantiate, IStaticDataService staticData){
            _instantiate = instantiate;
            _staticData = staticData;
        }

        public GameObject CreateHero(GameObject at){
            HeroGameObject = InstantiateRegister(AssetPath.HeroPath, at.transform.position);
            return HeroGameObject;
        }

        public GameObject CreateMonster(MonsterTypeId typeMonster, Transform parent){
            MonsterStaticData dataForMonsters = _staticData.DataForMonsters(typeMonster);
            GameObject monster = Object.Instantiate(dataForMonsters.Prefab, parent.position, quaternion.identity, parent);
            EnemyHealth enemyHealth = monster.GetComponent<EnemyHealth>();
            enemyHealth.CurrentHp = dataForMonsters.Hp;
            enemyHealth.MaxHp = dataForMonsters.Hp;
            monster.GetComponent<ActorUI>().SetHp(enemyHealth);
            monster.GetComponent<AgentMoveToPlayer>().SetHeroTransform(HeroGameObject.transform);
            monster.GetComponent<NavMeshAgent>().speed = dataForMonsters.MoveSpeed;
            monster.GetComponent<RotateToHero>()?.SetHeroTransform(HeroGameObject.transform);
            var componentInChildren = monster.GetComponentInChildren<LootSpawner>();
            componentInChildren.Constract(this);
            
            EnemyAttack enemyAttack = monster.GetComponent<EnemyAttack>();
            enemyAttack.SetHeroTransform(HeroGameObject.transform);
            enemyAttack.damage = dataForMonsters.Damage;
            enemyAttack.Cleavage = dataForMonsters.Cleavage;
            enemyAttack.EffectiveDistance = dataForMonsters.EffectiveDistance;
            
           
            
            return monster;
        }

        public GameObject CreateLoot(){
            
            return InstantiateRegister(AssetPath.LootPath);
        }

        public GameObject CreateHud(){
            return InstantiateRegister(AssetPath.HUDPath);
        }

        public void CleanUp(){
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegister(string path, Vector3 position){
            GameObject gameObject = _instantiate.Instantiate(path, position);
            //GameObject gameObject = _instantiate.Instantiate(path);

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

        public void Register(ISaveProgressReader progressReader){
            if (progressReader is ISaveProgress progressWriter){
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressReader);
        }
    }
}