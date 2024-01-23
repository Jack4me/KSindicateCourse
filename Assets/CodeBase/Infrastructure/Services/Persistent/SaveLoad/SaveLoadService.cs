using Data;
using Hero;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.Services.Persistent.SaveLoad {
   public class SaveLoadService : ISaveLoadService {
        private const string PROGRESS_KEY = "Progress";
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory){
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress(){
            foreach (ISaveProgress progressWriter in _gameFactory.ProgressWriters){
                progressWriter.UpdateProgress(_progressService.Progress); 
                PlayerPrefs.SetString(PROGRESS_KEY, _progressService.Progress.ToJson());
            }
        }
        
        public PlayerProgress LoadProgress(){
            string save = PlayerPrefs.GetString(PROGRESS_KEY);
            return save?.ToDeserlalized<PlayerProgress>();
        }
    }
}