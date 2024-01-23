using Infrastructure.Services;

namespace StaticData {
    public interface IStaticMonsterDataService : IService{
        void LoadMonsters();
        MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId);
        LevelStaticData ForLevel(string sceneNameKey);
    }
}