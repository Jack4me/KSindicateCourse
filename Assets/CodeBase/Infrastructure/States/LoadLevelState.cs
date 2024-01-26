using CameraLogic;
using Hero;
using Infrastructure.Factory;
using Infrastructure.Services.Persistent;
using UnityEngine;
using Infrastructure.States;
using Logic;
using StaticData;
using UI;
using UI.Elements;
using UnityEngine.SceneManagement;

namespace Infrastructure.States {
    public class LoadLevelState : ILoadLvlState<string> {
        private const string INITIAL_POINT = "InitialPoint";
        private const string ENEMYSPAWNER = "EnemySpawner";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, IPersistentProgressService persistentProgressService,
            IStaticDataService staticDataService){
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _persistentProgressService = persistentProgressService;
            _staticDataService = staticDataService;
        }

        public void Enter(string sceneName){
            _curtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit(){
            _curtain.Hide();
        }

        private void OnLoaded(){
            InitGameWorld();
            InformProgressReaders();
            _gameStateMachine.EnterGeneric<GameNewLoopState>();
        }

        private void InitGameWorld(){
            InitSpawners();
            GameObject hero = _gameFactory.CreateHero(at: GameObject.FindWithTag(INITIAL_POINT));
            InitHud(hero);
            CameraFollow(hero);
        }

        private void InitSpawners(){
            // foreach (GameObject spawnerObj in GameObject.FindGameObjectsWithTag(ENEMYSPAWNER)){
            //     var spawner = spawnerObj.GetComponent<EnemySpawner>();
            //     _gameFactory.Register(spawner);
            // }
            string sceneNameKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticDataService.ForLevel(sceneNameKey);
            foreach (EnemySpawnerData spawnerData in levelStaticData.EnemySpawnerDataList){
                _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.Id, spawnerData.MosterTypeId);
            }
        }

        private void InformProgressReaders(){
            foreach (ISaveProgressRLoader progressReader in _gameFactory.ProgressReaders){
                progressReader.LoadProgress(_persistentProgressService.Progress);
            }
        }

        private void InitHud(GameObject hero){
           GameObject hud =  _gameFactory.CreateHud();
           hud.GetComponentInChildren<ActorUI>().SetHp(hero.GetComponent<HeroHealth>());
               
        }

        private void CameraFollow(GameObject hero) => Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}