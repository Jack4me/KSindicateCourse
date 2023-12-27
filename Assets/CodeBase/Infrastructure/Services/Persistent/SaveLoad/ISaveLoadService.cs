using Data;

namespace Infrastructure.Services.Persistent.SaveLoad {
    public interface ISaveLoadService : IService{
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}