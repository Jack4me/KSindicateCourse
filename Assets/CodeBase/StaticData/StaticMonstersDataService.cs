using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace StaticData {
    public class StaticMonstersDataService : IStaticDataService {
        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;

        public StaticMonstersDataService([NotNull] Dictionary<MonsterTypeId, MonsterStaticData> monsterStaticDatas){
            _monsters = monsterStaticDatas ?? throw new ArgumentNullException(nameof(monsterStaticDatas));
        }

        public void LoadMonsters(){
            // _monsters = new Dictionary<MonsterTypeId, MonsterStaticData>();
            // MonsterStaticData[] monsterArray = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData");
            // foreach (MonsterStaticData monster in monsterArray){
            //     _monsters.Add(monster.MonsterEnumId, monster);
            // }
            _monsters = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData")
                .ToDictionary(x=> x.MonsterEnumId, x=>x);
        }

        public MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId){
            return _monsters.TryGetValue(monsterTypeId, out MonsterStaticData staticData) ? staticData : null;
        }
    }
}