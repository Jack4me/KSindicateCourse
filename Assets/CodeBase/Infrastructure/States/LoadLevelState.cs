using CameraLogic;
using Hero;
using Infrastructure.Factory;
using Infrastructure.Services.Persistent;
using UnityEngine;
using Infrastructure.States;

namespace Infrastructure.States {
    public class LoadLevelState : ILoadLvlState<string> {
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;

        public LoadLevelState(GameStateMachine GameStateMachine, SceneLoader SceneLoader, LoadingCurtain Curtain,
            IGameFactory GameFactory, IPersistentProgressService PersistentProgressService){
            _gameStateMachine = GameStateMachine;
            _sceneLoader = SceneLoader;
            _curtain = Curtain;
            _gameFactory = GameFactory;
            _persistentProgressService = PersistentProgressService;
        }

        public void Enter(string SceneName){
            _curtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(SceneName, OnLoaded);
        }

        public void Exit(){
            _curtain.Hide();
        }

        private void OnLoaded(){
            InitGameWorld();
            InformProgressReaders();
            _gameStateMachine.EnterGeneric<GameNewLoopState>();
        }

        private void InformProgressReaders(){
            foreach (ISaveProgressReader progressReader in _gameFactory.ProgressReaders){
                progressReader.LoadProgress(_persistentProgressService.Progress);
            }
        }

        private void InitGameWorld(){
            GameObject hero = _gameFactory.CreateHero(At: GameObject.FindWithTag(InitialPoint));
            InitHud(hero);
            CameraFollow(hero);
        }

        private void InitHud(GameObject Hero){
           GameObject hud =  _gameFactory.CreateHud();
           hud.GetComponentInChildren<ActorUI>().SetHp(Hero.GetComponent<HeroHealth>());
               
        }

        private void CameraFollow(GameObject Hero) => Camera.main.GetComponent<CameraFollow>().Follow(Hero);
    }
}