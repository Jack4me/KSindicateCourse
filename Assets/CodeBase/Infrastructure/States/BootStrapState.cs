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
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private AllServices _services;

        public BootStrapState(GameStateMachine GameStateMachine, SceneLoader SceneLoader, AllServices Services){
            _stateMachine = GameStateMachine;
            _sceneLoader = SceneLoader;
            _services = Services;
            RegisterServices();
        }

        public void Enter(){
            _sceneLoader.Load(Initial, OnLoaded: EnterLoadLevel);
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
                (_services.GetService<IInstantiateProvider>(), _services.GetService<IStaticDataService>(),
                    _services.GetService<IRandomService>(), _services.GetService<IPersistentProgressService>()));
            _services.RegisterService<ISaveLoadService>(new SaveLoadService(
                _services.GetService<IPersistentProgressService>(), _services.GetService<IGameFactory>()));
            // _services.RegisterService<IPersistentProgressService>(new PersistentProgressService());
        }

        private void RegisterStaticData(){
            IStaticDataService staticData = new StaticMonstersDataService();
            staticData.LoadMonsters();
            _services.RegisterService<IStaticDataService>(staticData);
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