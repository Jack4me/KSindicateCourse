using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using StaticData.Windows;
using UI.Services;
using UI.Services.Windows;
using UnityEngine;

namespace StaticData {
    public class StaticDataService : IStaticDataService {
        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowIdEnum, WindowConfig> _windowConfig;

        public StaticDataService([NotNull] Dictionary<MonsterTypeId, MonsterStaticData> monsterStaticDatas){
            _monsters = monsterStaticDatas ?? throw new ArgumentNullException(nameof(monsterStaticDatas));
        }

        public void Load(){

            // _monsters = new Dictionary<MonsterTypeId, MonsterStaticData>();
            // MonsterStaticData[] monsterArray = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData");
            // foreach (MonsterStaticData monster in monsterArray){
            //     _monsters.Add(monster.MonsterEnumId, monster);
            // }
            _monsters = Resources.LoadAll<MonsterStaticData>("StaticData/EnemyData")
                .ToDictionary(x => x.MonsterEnumId, x => x);
            
            
            _levels = Resources.LoadAll<LevelStaticData>("StaticData/LevelsData")
                .ToDictionary(x => x.LevelKey, x => x);

            _windowConfig = Resources
                .Load<WindowStaticData>("StaticData/WindowsData/WindowStaticData")
                .ConfigsList
                .ToDictionary(x => x.WindowId, x => x);

        }

        public MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId){
            return _monsters.TryGetValue(monsterTypeId, out MonsterStaticData monsterStaticData) ? monsterStaticData : null;
        }

        public LevelStaticData ForLevel(string sceneNameKey){
            
               return _levels.TryGetValue(sceneNameKey, out LevelStaticData levelStaticData) ? levelStaticData : null;
               
        }

        public WindowConfig ForWindow(WindowIdEnum windowId){
            return _windowConfig.TryGetValue(windowId, out WindowConfig windowConfig) ? windowConfig : null;
            // bool tryGetValue = _windowConfig.TryGetValue(windowId, out WindowConfig windowConfig);
            // return tryGetValue ? windowConfig : null;
        }
    }
}