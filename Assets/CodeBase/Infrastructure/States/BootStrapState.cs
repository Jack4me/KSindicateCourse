﻿using System.Collections.Generic;
using System.Linq;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using Infrastructure.Services.Persistent.SaveLoad;
using Infrastructure.Services.Randomizer;
using Services.Input;
using StaticData;
using UnityEngine;

namespace Infrastructure.States {
    class BootStrapState : IState {
        private const string INITIAL = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private AllServices _services;

        public BootStrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services){
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter(){
            _sceneLoader.Load(INITIAL, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel(){
            _stateMachine.EnterGeneric<LoadProgressState>();
        }

        private void RegisterServices(){
            RegisterStaticData();
            _services.RegisterService<IInstantiateProvider>(new InstantiateProvider());
            _services.RegisterService<IRandomService>(new RandomService());
            _services.RegisterService<IInputService>(RegisterInputServices());
            _services.RegisterService<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterService<IGameFactory>(new GameFactory
            (_services.GetService<IInstantiateProvider>(), _services.GetService<IStaticMonsterDataService>(),
                _services.GetService<IRandomService>(), _services.GetService<IPersistentProgressService>()));
            _services.RegisterService<ISaveLoadService>(new SaveLoadService(
                _services.GetService<IPersistentProgressService>(), _services.GetService<IGameFactory>()));
        }

        private void RegisterStaticData(){
            Dictionary<MonsterTypeId, MonsterStaticData> monsterStaticDatas
                = Resources.LoadAll<MonsterStaticData>("Enemies/EnemyData")
                .ToDictionary(x=> x.MonsterEnumId, x=>x);
            IStaticMonsterDataService staticMonsterData = new StaticMonstersDataService(monsterStaticDatas);
            
            //staticData.LoadMonsters();
            _services.RegisterService<IStaticMonsterDataService>(staticMonsterData);
        }

        public void Exit(){
        }

        private static IInputService RegisterInputServices(){
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}