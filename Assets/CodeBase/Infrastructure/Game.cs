using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure {
    public class Game {
       // public static IInputService InputService;
        public GameStateMachine StateMachine;
        public Game(ICoroutineRunner CoroutineRunner, LoadingCurtain Curtain){
            StateMachine = new GameStateMachine(new SceneLoader(CoroutineRunner), Curtain, AllServices.Container);
        }
    }
}