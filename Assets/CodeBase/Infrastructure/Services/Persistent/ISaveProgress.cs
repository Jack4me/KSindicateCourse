﻿using Data;

namespace Infrastructure.Services.Persistent {
    public interface ISaveProgressReader {
        void LoadProgress(PlayerProgress PlayerProgress);

    }

    public interface ISaveProgress : ISaveProgressReader {
        void UpdateProgress(PlayerProgress PlayerProgress);

    }
}