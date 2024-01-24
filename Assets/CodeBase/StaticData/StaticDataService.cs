using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace StaticData {
    public class StaticDataService : IStaticDataService {
        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;

        public StaticDataService([NotNull] Dictionary<MonsterTypeId, MonsterStaticData> monsterStaticDatas){
            _monsters = monsterStaticDatas ?? throw new ArgumentNullException(nameof(monsterStaticDatas));
        }

        public void Load(){
            // _monsters = new Dictionary<MonsterTypeId, MonsterStaticData>();
            // MonsterStaticData[] monsterArray = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData");
            // foreach (MonsterStaticData monster in monsterArray){
            //     _monsters.Add(monster.MonsterEnumId, monster);
            // }
            _monsters = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData")
                .ToDictionary(x => x.MonsterEnumId, x => x);
            _levels = Resources.LoadAll<LevelStaticData>("Enemies/LevelsData")
                .ToDictionary(x => x.LevelKey, x => x);
           
                Debug.Log("ne NULL");
        }

        public MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId){
            return _monsters.TryGetValue(monsterTypeId, out MonsterStaticData staticData) ? staticData : null;
        }

        public LevelStaticData ForLevel(string sceneNameKey){
            
            return _levels.TryGetValue(sceneNameKey, out LevelStaticData staticData) ? staticData : null;
        }
    }
}