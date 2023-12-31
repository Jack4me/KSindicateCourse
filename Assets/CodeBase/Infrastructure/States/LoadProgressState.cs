using Data;
using Infrastructure.Services.Persistent;
using Infrastructure.Services.Persistent.SaveLoad;

namespace Infrastructure.States {
    public class LoadProgressState : IState{
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoaderService;

        public LoadProgressState(GameStateMachine GameStateMachine, IPersistentProgressService PersistentProgressService,ISaveLoadService SaveLoaderService){
            _gameStateMachine = GameStateMachine;
            _persistentProgressService = PersistentProgressService;
            _saveLoaderService = SaveLoaderService;
        }

        public void Enter(){
            LoadProgressOrInitNew();
            _gameStateMachine.EnterGeneric<LoadLevelState, string>(
                _persistentProgressService.Progress.worldData.positionAtLvL.lvLName);
        }

        public void Exit(){
        }

        private void LoadProgressOrInitNew(){
             _persistentProgressService.Progress = _saveLoaderService.LoadProgress() ?? NewProgress();
            // _persistentProgressService.Progress = NewProgress();
           
        }

        private PlayerProgress NewProgress(){
            var progress = new PlayerProgress("SampleScene");
            progress.stateHeroHp.maxHp = 50;
            progress.HeroStats.Damage = 1f;
            progress.HeroStats.DamageRadius = 1f;
            progress.stateHeroHp.ResetHp();
            
            
            return progress;
            
            
        }
    }
}