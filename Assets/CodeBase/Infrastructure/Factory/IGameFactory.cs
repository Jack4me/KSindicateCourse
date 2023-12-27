using System;
using System.Collections.Generic;
using Hero;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory {
    public interface IGameFactory : IService {
        List<ISaveProgressReader> ProgressReaders{ get; }
        List<ISaveProgress> ProgressWriters{ get; }
        GameObject CreateHero(GameObject At);
        GameObject HeroGameObject{ get; }

        event Action HeroCreated;
        GameObject CreateHud();
        void CleanUp();
    }

    
}