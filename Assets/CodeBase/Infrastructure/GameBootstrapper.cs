using Infrastructure.States;
using UnityEngine;

namespace Infrastructure {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        private Game _game;
        public LoadingCurtain curtainPrefab;
        private void Awake(){
            _game = new Game(this, Instantiate(curtainPrefab) );
            _game.StateMachine.EnterGeneric<BootStrapState>();
            DontDestroyOnLoad(this);
            
        }
    }
}