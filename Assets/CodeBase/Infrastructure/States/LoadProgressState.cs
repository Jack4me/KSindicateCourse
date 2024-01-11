using Data;
using Infrastructure.Services.Persistent;
using Infrastructure.Services.Persistent.SaveLoad;

namespace Infrastructure.States {
    public class LoadProgressState : IState{
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoaderService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService persistentProgressService,ISaveLoadService saveLoaderService){
            _gameStateMachine = gameStateMachine;
            _persistentProgressService = persistentProgressService;
            _saveLoaderService = saveLoaderService;
        }

        public void Enter(){
            LoadProgressOrInitNew();
            _gameStateMachine.EnterGeneric<LoadLevelState, string>(
                _persistentProgressService.Progress.WorldData.positionAtLvL.lvLName);
        }

        public void Exit(){
        }

        private void LoadProgressOrInitNew(){
             _persistentProgressService.Progress = _saveLoaderService.LoadProgress() ?? NewProgress();
             //_persistentProgressService.Progress = NewProgress();
           
        }

        private PlayerProgress NewProgress(){
            var progress = new PlayerProgress("SampleScene");
            progress.StateHeroHp.maxHp = 50;
            progress.HeroStats.Damage = 1f;
            progress.HeroStats.DamageRadius = 1f;
            progress.StateHeroHp.ResetHp();
            
            
            return progress;
            
            
        }
    }
}