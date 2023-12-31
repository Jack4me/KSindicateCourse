using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure {
    public class Game {
       // public static IInputService InputService;
        public GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain){
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
        }
    }
}