using Data;

namespace Infrastructure.Services.Persistent {
    public interface ISaveProgressReader {
        void LoadProgress(PlayerProgress playerProgress);

    }

    public interface ISaveProgress : ISaveProgressReader {
        void UpdateProgress(PlayerProgress playerProgress);

    }
}