using System.Collections.Generic;
using Hero;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory {
    public interface IGameFactory : IService {
        List<ISaveProgressReader> ProgressReaders{ get; }
        List<ISaveProgress> ProgressWriters{ get; }
        GameObject CreateHero(GameObject At);

        GameObject CreateHud();
        void CleanUp();
        public void Register(ISaveProgressReader progressReader);
        GameObject CreateMonster (MonsterTypeId typeMonster, Transform transform);
        GameObject CreateLoot();
    }

    
}