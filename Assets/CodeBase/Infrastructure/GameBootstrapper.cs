using Infrastructure.States;
using UnityEngine;

namespace Infrastructure {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        private Game _game;
        public LoadingCurtain curtainPrefab;
        private void Awake(){
            LoadingCurtain loadingCurtain = Instantiate(curtainPrefab);
            _game = new Game(this, loadingCurtain);
            _game.StateMachine.EnterGeneric<BootStrapState>();
            DontDestroyOnLoad(this);
        }
    }
}