namespace Infrastructure.States {

    public interface IExitableState {
        void Exit();

    }
    public interface IState : IExitableState{
        void Enter();
    }
    public interface ILoadLvlState<TLoadScene> : IExitableState{
        void Enter(TLoadScene LoadLvl);
    }
    
}