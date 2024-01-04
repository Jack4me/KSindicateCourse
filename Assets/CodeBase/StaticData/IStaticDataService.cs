using Infrastructure.Services;

namespace StaticData {
    public interface IStaticDataService : IService{
        void LoadMonsters();
        MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId);
    }
}