using Infrastructure.Services;
using UI.Services;
using UI.Services.Windows;

namespace StaticData {
    public interface IStaticDataService : IService{
        void Load();
        MonsterStaticData DataForMonsters(MonsterTypeId monsterTypeId);
        LevelStaticData ForLevel(string sceneNameKey);
        WindowConfig ForWindow(WindowIdEnum shop);
    }
}