using System.Collections.Generic;
using Enemy;
using Hero;
using Infrastructure.Services;
using Infrastructure.Services.Persistent;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory {
    public interface IGameFactory : IService {
        List<ISaveProgressRLoader> ProgressReaders{ get; }
        List<ISaveProgress> ProgressWriters{ get; }
        GameObject CreateHero(GameObject at);

        GameObject CreateHud();
        void CleanUp();
        public void Register(ISaveProgressRLoader progressRLoader);
        GameObject CreateMonster (MonsterTypeId typeMonster, Transform transform);
        LootPiece CreateLoot();
    }

    
}