using Data;

namespace Infrastructure.Services.Persistent {
    public interface ISaveProgressRLoader {
        void LoadProgress(PlayerProgress playerProgress);

    }

    public interface ISaveProgress : ISaveProgressRLoader {
        void UpdateProgress(PlayerProgress playerProgress);

    }
}