using Infrastructure.Services;

namespace StaticData {
    public interface IStaticDataService : IService{
        void LoadMonsters();
        MonsterStaticData DataMonsters(MonsterTypeId monsterTypeId);
    }
}