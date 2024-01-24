using Infrastructure.Services;

namespace StaticData {
    public interface IStaticDataService : IService{
        void Load();
        MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId);
        LevelStaticData ForLevel(string sceneNameKey);
    }
}