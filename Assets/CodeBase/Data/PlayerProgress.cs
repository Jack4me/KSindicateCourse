using System;

namespace Data {
    [Serializable]
    public class PlayerProgress {
        public StateHp stateHeroHp;
        public WorldData worldData;
        public KillData KillData;
        public HeroStats HeroStats;

        public PlayerProgress(string initialLevel){
            KillData = new KillData();
            worldData = new WorldData(initialLevel);
            stateHeroHp = new StateHp();
            HeroStats = new HeroStats();
        }
    }
}