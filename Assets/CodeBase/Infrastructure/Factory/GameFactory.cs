using System.Collections.Generic;
using Enemy;
using Hero;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.Persistent;
using Infrastructure.Services.Randomizer;
using StaticData;
using UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Infrastructure.Factory {
    public class GameFactory : IGameFactory {
        private readonly IInstantiateProvider _instantiate;
        private readonly IStaticDataService _staticData;
        private readonly IRandomService _random;
        private readonly IPersistentProgressService _persistentProgressService;
        public List<ISaveProgressRLoader> ProgressReaders{ get; } = new List<ISaveProgressRLoader>();
        public List<ISaveProgress> ProgressWriters{ get; } = new List<ISaveProgress>();

        public GameObject HeroGameObject{ get; set; }

        public GameFactory(IInstantiateProvider instantiate, IStaticDataService staticData, IRandomService random,
            IPersistentProgressService persistentProgressService){
            _instantiate = instantiate;
            _staticData = staticData;
            _random = random;
            _persistentProgressService = persistentProgressService;
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
            var lootSpawner = monster.GetComponentInChildren<LootSpawner>();
            lootSpawner.SetLoot(dataForMonsters.MaxLoot, dataForMonsters.MaxLoot);
            lootSpawner.Constract(this, _random);
            
            EnemyAttack enemyAttack = monster.GetComponent<EnemyAttack>();
            enemyAttack.SetHeroTransform(HeroGameObject.transform);
            enemyAttack.damage = dataForMonsters.Damage;
            enemyAttack.Radius = dataForMonsters.Radius;
            enemyAttack.EffectiveDistance = dataForMonsters.EffectiveDistance;
            
            return monster;
        }

        public LootPiece CreateLoot(){
            
               GameObject newLoot = InstantiateRegister(AssetPath.LootPath);
               LootPiece lootPiece = newLoot.GetComponent<LootPiece>();
               
               lootPiece.Construct(_persistentProgressService.Progress.WorldData);
               return lootPiece;
        }

        public GameObject CreateHud(){
            var hud = InstantiateRegister(AssetPath.HUDPath);
           hud.GetComponentInChildren<LootCounter>().Construct(_persistentProgressService.Progress.WorldData);
            return hud;
        }

        public void CleanUp(){
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegister(string path, Vector3 position){
            GameObject gameObject = _instantiate.Instantiate(path, position);
           
            RegisterProgressWatcher(gameObject);
            return gameObject;
        }
        
        private GameObject InstantiateRegister(string path){
            GameObject gameObject = _instantiate.Instantiate(path);
            RegisterProgressWatcher(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatcher(GameObject hero){
            foreach (ISaveProgressRLoader progressReader in hero.GetComponentsInChildren<ISaveProgressRLoader>()){
                Register(progressReader);
            }
        }

        public void Register(ISaveProgressRLoader progressRLoader){
            if (progressRLoader is ISaveProgress progressWriter){
                ProgressWriters.Add(progressWriter);
            }
            ProgressReaders.Add(progressRLoader);
        }
    }
}