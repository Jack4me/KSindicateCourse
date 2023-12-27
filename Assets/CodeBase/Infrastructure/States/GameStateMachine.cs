using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using Infrastructure.Services.Persistent.SaveLoad;

namespace Infrastructure.States {
    public class GameStateMachine {
        private readonly Dictionary<Type, IExitableState> _state;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader SceneLoader, LoadingCurtain Curtain, AllServices Services){
            _state = new Dictionary<Type, IExitableState>{
                [typeof(BootStrapState)] = new BootStrapState(this, SceneLoader, Services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, SceneLoader, Curtain, 
                    Services.GetService<IGameFactory>(), Services.GetService<IPersistentProgressService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this,
                    Services.GetService<IPersistentProgressService>(), Services.GetService<ISaveLoadService>()),
                [typeof(GameNewLoopState)] = new GameNewLoopState(this)
            };
        }

        public void EnterGeneric<TState>() where TState : class, IState{
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void EnterGeneric<TState, TLoadScene>(TLoadScene LoadScene) 
            where TState : class, ILoadLvlState<TLoadScene>{
            TState state = ChangeState<TState>();
            state.Enter(LoadScene);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState{
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState{
            return _state[typeof(TState)] as TState;
        }
        //структура не может наследовать другую структуру
    }
}