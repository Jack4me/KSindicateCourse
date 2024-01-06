using Data;
using Hero;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.Services.Persistent.SaveLoad {
   public class SaveLoadService : ISaveLoadService {
        private const string ProgressKey = "Progress";
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory){
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress(){
            foreach (ISaveProgress progressWriter in _gameFactory.ProgressWriters){
                progressWriter.UpdateProgress(_progressService.Progress); 
                PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
            }
        }
        
        public PlayerProgress LoadProgress(){
            string save = PlayerPrefs.GetString(ProgressKey);
            return save?.ToDeserlalized<PlayerProgress>();
        }
    }
}