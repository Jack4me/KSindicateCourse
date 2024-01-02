using CameraLogic;
using Hero;
using Infrastructure.Factory;
using Infrastructure.Services.Persistent;
using UnityEngine;
using Infrastructure.States;
using Logic;

namespace Infrastructure.States {
    public class LoadLevelState : ILoadLvlState<string> {
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, IPersistentProgressService persistentProgressService){
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter(string sceneName){
            _curtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit(){
            _curtain.Hide();
        }

        private void InitGameWorld(){
            InitSpawners();
            GameObject hero = _gameFactory.CreateHero(At: GameObject.FindWithTag(InitialPoint));
            InitHud(hero);
            CameraFollow(hero);
        }

        private void InitSpawners(){
            foreach (GameObject spawnerObj in GameObject.FindGameObjectsWithTag("EnemySpawner")){
                var spawner = spawnerObj.GetComponent<EnemySpawner>();
                _gameFactory.
            }
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

        private void InitHud(GameObject Hero){
           GameObject hud =  _gameFactory.CreateHud();
           hud.GetComponentInChildren<ActorUI>().SetHp(Hero.GetComponent<HeroHealth>());
               
        }

        private void CameraFollow(GameObject Hero) => Camera.main.GetComponent<CameraFollow>().Follow(Hero);
    }
}